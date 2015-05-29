
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
using System.Collections.Generic;

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

  public static string debug (string msg)
    {
      return log(msg, "DBG", LOGLEVEL_DEBUG);
    }

  public static string debug_json (string args)
    {
      return debug(Json.decode(args).asArray()[0].asValue<string>());
    }

  public static string info (string msg)
    {
      return log(msg, "INF", LOGLEVEL_INFO);
    }

  public static string info_json (string args)
    {
      return info(Json.decode(args).asArray()[0].asValue<string>());
    }

  public static string warning (string msg)
    {
      return log(msg, "WRN", LOGLEVEL_WARNING);
    }

  public static string warning_json (string args)
    {
      return warning(Json.decode(args).asArray()[0].asValue<string>());
    }

  public static string error (string msg)
    {
      return log(msg, "ERR", LOGLEVEL_ERROR);
    }

  public static string error_json (string args)
    {
      return error(Json.decode(args).asArray()[0].asValue<string>());
    }

  public static string critical (string msg)
    {
      return log(msg, "CRT", LOGLEVEL_CRITICAL);
    }

  public static string critical_json (string args)
    {
      return critical(Json.decode(args).asArray()[0].asValue<string>());
    }

  private static string log (string msg, string loglevel_str, int loglevel)
    {
      if (loglevel < minimumLoglevel)
        return null;

      string s = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "][" + loglevel_str + "] " + msg;

      // write to pyKOS log
      logfile.WriteLine(s);
      // write to KSP log
      Console.WriteLine(s);

      return null;
    }

}

}

