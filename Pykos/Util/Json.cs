
using System;
using System.Collections.Generic;

namespace PyKOS.Util
{

public class JsonException : Exception
{
  public JsonException () { }
  public JsonException (string msg) : base(msg) { }
  public JsonException (string msg, Exception inner) : base(msg, inner) { }
}

public class Json
{

  private string str = null;

  object value = null;

  public Json (string s)
    {
      str = s.Trim();
      value = parse(str);
    }

  public static Json decode (string s)
    {
      return new Json(s);
    }

  public List<Json> asArray ()
    {
      if (!(value is List<Json>))
        throw new JsonException("not a valid JSON array: '" + str + "'");

      return (List<Json>)value;
    }

  public Dictionary<string, Json> asObject ()
    {
      if (!(value is Dictionary<string, Json>))
        throw new JsonException("not a valid JSON object: '" + str + "'");

      return (Dictionary<string, Json>)value;
    }

  public T asValue<T> ()
    {
      if (value is List<Json> || value is Dictionary<string, Json>)
        throw new JsonException("not a valid JSON value: '" + str + "'");

      try
        {
          return (T)Convert.ChangeType(value, typeof(T));
        }
      catch (Exception e)
        {
          throw new JsonException("can not be converted to " + typeof(T).Name + ": '" + str + "'", e);
        }

    }

  private static object parse (string s)
    {
      Console.WriteLine("parsing: '" + s + "'");

      if (s.Equals("null"))
        return null;
      if (s.Equals("true"))
        return true;
      if (s.Equals("false"))
        return false;

      if (s.StartsWith("\"") && s.EndsWith("\""))
        return s.Substring(1, s.Length - 2).Replace("\\\"", "\"");

      if (s.StartsWith("[") && s.EndsWith("]"))
        return parseArray(s.Substring(1, s.Length - 2).Trim());
      if (s.StartsWith("{") && s.EndsWith("}"))
        return parseObject(s.Substring(1, s.Length - 2).Trim());

      try
        {
          return float.Parse(s);
        }
      catch (Exception e)
        {
          throw new JsonException("is not a valid number: '" + s + "'", e);
        }
    }

  private static object parseArray (string s)
    {
      List<Json> values = new List<Json>();

      while (s != "")
        {
          int token_end;
          if (s[0] == '"')
            token_end = seekStringTokenEnd(s);
          else if (s[0] == '[')
            token_end = seekArrayTokenEnd(s);
          else if (s[0] == '{')
            token_end = seekObjectTokenEnd(s);
          else
            token_end = s.IndexOf(',') - 1;

          string head = (token_end >= 0) ? s.Substring(0, token_end + 1) : s;
          s = (token_end >= 0) ? s.Substring(token_end + 1).Trim() : "";

          Console.WriteLine("head: '" + head + "'; tail: '" + s + "'");

          values.Add(new Json(head));

          if (s != "")
            {
              if (s[0] != ',')
                throw new JsonException("unexpected characters out of token near '" + s + "'");
              s = s.Substring(1).Trim();
              if (s == "")
                throw new JsonException("unexpected end of array");
            }
        }

      return values;
    }

  private static int seekStringTokenEnd (string s)
    {
      int pos = 0;
      do
        pos = s.IndexOf('"', pos + 1);
      while (pos > 0 && s[pos - 1] == '\\');

      return pos;
    }

  private static int seekArrayTokenEnd (string s)
    {
      throw new NotImplementedException();
    }

  private static int seekObjectTokenEnd (string s)
    {
      throw new NotImplementedException();
    }

  private static object parseObject (string s)
    {
      throw new NotImplementedException();
    }
}

}

