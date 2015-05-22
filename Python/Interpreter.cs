
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

using pykos.Util;

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace pykos.Python
{

public delegate void TPykosLoggingCallback (string str);
public delegate void TPykosOutputCallback (char c);

public static class Interpreter
{
  private static Queue<string> lineBuffer = new Queue<string>();

  public static string output { get { return String.Join("\n", lineBuffer.ToArray()); } }

  [DllImport("pykos/libs/libsteelpython_c.so")]
  static extern void libsteelpython_registerOutputCallbacks (
    TPykosOutputCallback pykosOutputCallback,
    TPykosLoggingCallback pykosLoggingDebugCallback,
    TPykosLoggingCallback pykosLoggingInfoCallback,
    TPykosLoggingCallback pykosLoggingWarningCallback,
    TPykosLoggingCallback pykosLoggingErrorCallback,
    TPykosLoggingCallback pykosLoggingCriticalCallback
  );

  [DllImport("pykos/libs/libsteelpython_c.so")]
  static extern void libsteelpython_initialize ();

  public static void initialize ()
    {
      Logging.info("initializing Interpreter");

      libsteelpython_registerOutputCallbacks(
        onOutputCallback,
        Logging.debug,
        Logging.info,
        Logging.warning,
        Logging.error,
        Logging.critical
      );

      libsteelpython_initialize();
    }

  [DllImport("pykos/libs/libsteelpython_c.so")]
  static extern void libsteelpython_execute (string code);
  public static void execute (string code)
    {
      libsteelpython_execute(code);
    }

  private static string line = "";
  public static void onOutputCallback (char c)
    {
      if (c == '\n')
        {
          lineBuffer.Enqueue(line);
          line = "";
        }
      else if (c != '\r')
        line += c;
    }

}

}

