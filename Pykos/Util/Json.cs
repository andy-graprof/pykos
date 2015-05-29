
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

enum JsonType
{
  JSON_ARRAY,
  JSON_OBJECT,
  JSON_VALUE
};

public class Json
{

  private string str = null;

  object value = null;
  JsonType type = JsonType.JSON_VALUE;

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
      if (type != JsonType.JSON_ARRAY)
        throw new JsonException("is not a valid JSON array: '" + str + "'");

      return (List<Json>)value;
    }

  public Dictionary<string, Json> asObject ()
    {
      if (type != JsonType.JSON_OBJECT)
        throw new JsonException("is not a valid JSON object: '" + str + "'");

      return (Dictionary<string, Json>)value;
    }

  public T asValue<T> ()
    {
      if (type != JsonType.JSON_VALUE)
        throw new JsonException("is not a valid JSON value: '" + str + "'");

      try
        {
          return (T)Convert.ChangeType(value, typeof(T));
        }
      catch (Exception e)
        {
          throw new JsonException("invalid conversion requested: '" + str + "' to " + typeof(T).Name, e);
        }

    }

  private static object parse (string s)
    {
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
          if (s.StartsWith("\""))
            {
              int pos = 0;
              do
                pos = s.IndexOf('"', pos + 1);
              while (pos > 0 && s[pos - 1] == '\\');
              if (pos == -1)
                throw new JsonException("unterminated json string: '" + s + "'");
              values.Add(new Json(s.Substring(0, pos)));
              s = s.Substring(pos + 1).Trim();
            }
          else if (s.StartsWith("["))
            {
              int pos = 0;
              int depth = 1;
              do
                {
                  pos = s.IndexOfAny(new char[] { '[', ']' }, pos + 1);
                  depth += ((s[pos] == '[') ? 1 : -1);
                }
              while (pos > 0 && depth > 0);
              if (pos == -1)
                throw new JsonException("unterminated json array: '" + s + "'");
              values.Add(new Json(s.Substring(0, pos)));
              s = s.Substring(pos + 1).Trim();
            }
          else if (s.StartsWith("{"))
            {
              int pos = 0;
              int depth = 1;
              do
                {
                  pos = s.IndexOfAny(new char[] { '{', '}' }, pos + 1);
                  depth += ((s[pos] == '{') ? 1 : -1);
                }
              while (pos > 0 && depth > 0);
              if (pos == -1)
                throw new JsonException("unterminated json object: '" + s + "'");
              values.Add(new Json(s.Substring(0, pos)));
              s = s.Substring(pos + 1).Trim();
            }
          else
            {
              int pos = s.IndexOf(' ');
              if (pos == -1)
                {
                  values.Add(new Json(s));
                  s = "";
                }
              else
                {
                  values.Add(new Json(s.Substring(0, pos)));
                  s = s.Substring(pos + 1).Trim();
                }
            }

          if (s != "" && !s.StartsWith(","))
            throw new JsonException("unexpected token in input: '" + s + "'");

          if (s != "")
            s = s.Substring(1);
        }

      return values;
    }

  private static object parseObject (string s)
    {
      Dictionary<string, Json> values = new Dictionary<string, Json>();

      return values;
    }
}

}

