
/******************************************************************************
 *                    pykos - bringing python to KSP                          *
 *                                                                            *
 *    Copyright (C) 2015  Andreas Grapentin                                   *
 *                                                                            *
 *    This program is free software: you can redistribute it and/or modify    *
 *    it under the terms of the GNU General Public License as published by    *
 *    the Free Software Foundation, either version 3 of the License, or       *
 *    (at your option) any later version.                                     *
 *                                                                            *
 *    This program is distributed in the hope that it will be useful,         *
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of          *
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *
 *    GNU General Public License for more details.                            *
 *                                                                            *
 *    You should have received a copy of the GNU General Public License       *
 *    along with this program.  If not, see <http://www.gnu.org/licenses/>.   *
 ******************************************************************************/

using System;
using System.IO;

namespace PyKOS.Util
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

