
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
  public void JsonValueTest_Array ()
    {
      List<Json> res = Json.decode("[null,true,false,\"hello world\",42,42.2]").asArray();
      Assert.AreEqual(null, res[0].asValue<object>());
      Assert.AreEqual(true, res[1].asValue<bool>());
      Assert.AreEqual(false, res[2].asValue<bool>());
      Assert.AreEqual("hello world", res[3].asValue<string>());
      Assert.AreEqual(42, res[4].asValue<int>());
      Assert.AreEqual(42.2, res[5].asValue<float>());
    }

}

}

