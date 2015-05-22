
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

