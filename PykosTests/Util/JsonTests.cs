
using System;
using System.Collections.Generic;
using NUnit.Framework;

using PyKOS.Util;

namespace PyKOS.Tests.Util
{

[TestFixture ()]
public class JsonTests
{
  [Test ()]
  public void JsonValueTest_null ()
    {
      Assert.AreEqual(null, Json.decode("null").asValue<object>());
    }

  [Test ()]
  public void JsonValueTest_bool ()
    {
      Assert.AreEqual(true, Json.decode("true").asValue<bool>());
      Assert.AreEqual(false, Json.decode("false").asValue<bool>());
    }

  [Test ()]
  public void JsonValueTest_string ()
    {
      Assert.AreEqual("hello world", Json.decode("\"hello world\"").asValue<string>());
      Assert.AreEqual("\"", Json.decode("\"\\\"\"").asValue<string>());
      Assert.AreEqual("\n", Json.decode("\"\n\"").asValue<string>());
    }

  [Test ()]
  public void JsonValueTest_number ()
    {
      Assert.AreEqual(42, Json.decode("42").asValue<int>());
      Assert.AreEqual(42.2, Json.decode("42.2").asValue<float>(), 0.001);
      Assert.AreEqual(42.2, Json.decode("42.2").asValue<double>(), 0.001);
      Assert.AreEqual(42, Json.decode("42.2").asValue<int>());
    }

  [Test ()]
  public void JsonValueTest_validConversion ()
    {
      Assert.AreEqual(42, Json.decode("\"42\"").asValue<int>());
      Assert.AreEqual(42.2, Json.decode("\"42.2\"").asValue<float>(), 0.001);
      Assert.AreEqual(42.2, Json.decode("\"42.2\"").asValue<double>(), 0.001);

      Assert.AreEqual("42", Json.decode("42").asValue<string>());
      Assert.AreEqual("42.2", Json.decode("42.2").asValue<string>());
      Assert.AreEqual("42.2", Json.decode("42.2").asValue<string>());
    }

  [Test ()]
  public void JsonValueTest_invalidConversion ()
    {
      Assert.Throws<JsonException>(delegate { Json.decode("\"hello\"").asValue<int>(); } );
      Assert.Throws<JsonException>(delegate { Json.decode("\"hello\"").asValue<float>(); } );
      Assert.Throws<JsonException>(delegate { Json.decode("\"hello\"").asValue<double>(); } );

      Assert.Throws<JsonException>(delegate { Json.decode("\"42.2\"").asValue<int>(); } );
    }

  [Test ()]
  public void JsonValueTest_invalidValue ()
    {
      Assert.Throws<JsonException>(delegate { Json.decode("noll").asValue<object>(); } );
    }

  [Test ()]
  public void JsonArrayTest_valid ()
    {
      Assert.AreEqual(new List<Json>(), Json.decode("[]").asArray());
      Assert.AreEqual(new List<Json>(), Json.decode("[ \t ]").asArray());
      Assert.AreEqual(null, Json.decode("[null]").asArray()[0].asValue<object>());
      Assert.AreEqual("hello", Json.decode("[\"hello\",\"world\"]").asArray()[0].asValue<string>());
      Assert.AreEqual("world", Json.decode("[\"hello\",\"world\"]").asArray()[1].asValue<string>());
      Assert.AreEqual("hello", Json.decode("[  \"hello\"  ,  \"world\"  ]").asArray()[0].asValue<string>());
      Assert.AreEqual("world", Json.decode("[  \"hello\"  ,  \"world\"  ]").asArray()[1].asValue<string>());
      Assert.AreEqual("hello\"", Json.decode("[\"hello\\\"\",\"world\"]").asArray()[0].asValue<string>());
      Assert.AreEqual("\"world", Json.decode("[\"hello\",\"\\\"world\"]").asArray()[1].asValue<string>());
    }

  [Test ()]
  public void JsonArrayTest_invalid ()
    {
      Assert.Throws<JsonException>(delegate { Json.decode("[,null]").asValue<object>(); } );
      Assert.Throws<JsonException>(delegate { Json.decode("[null,]").asValue<object>(); } );
      Assert.Throws<JsonException>(delegate { Json.decode("[").asValue<object>(); } );
    }
}

}

