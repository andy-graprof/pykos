
using System;
using System.IO;

namespace pykos.Util
{

internal static class Logging
{

  private static string logfilename = "pykos/pykos.log";
  private static StreamWriter logfile;

  public const int LOGLEVEL_NOTSET   =  0;
  public const int LOGLEVEL_DEBUG    = 10;
  public const int LOGLEVEL_INFO     = 20;
  public const int LOGLEVEL_WARNING  = 30;
  public const int LOGLEVEL_ERROR    = 40;
  public const int LOGLEVEL_CRITICAL = 50;

  public static int minimumLoglevel { get; set; }

  static Logging ()
    {
      minimumLoglevel = LOGLEVEL_NOTSET;

      logfile = new StreamWriter(logfilename);
      logfile.AutoFlush = true;
    }

  public static void debug (string msg)
    {
      log(msg, "DBG", LOGLEVEL_DEBUG);
    }

  public static void info (string msg)
    {
      log(msg, "INF", LOGLEVEL_INFO);
    }

  public static void warning (string msg)
    {
      log(msg, "WRN", LOGLEVEL_WARNING);
    }

  public static void error (string msg)
    {
      log(msg, "ERR", LOGLEVEL_ERROR);
    }

  public static void critical (string msg)
    {
      log(msg, "CRT", LOGLEVEL_CRITICAL);
    }

  private static void log (string msg, string loglevel_str, int loglevel)
    {
      if (loglevel < minimumLoglevel)
        return;

      string s = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "][" + loglevel_str + "] " + msg;

      // write to pyKOS log
      logfile.WriteLine(s);
      // write to KSP log
      Console.WriteLine(s);
    }

}

}

