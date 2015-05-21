
using pykos.Util;
using pykos.Gui;
using pykos.Python;

using System;
using UnityEngine;

namespace pykos
{

public static class PyKOS
{

  public static void Awake ()
    {
      Logging.info("This is pyKOS!");
      Logging.debug("starting pyKOS initialization phase");
      
      GuiManager.initialize();
      Interpreter.initialize();
      
      Logging.debug("pyKOS initialization phase complete");
    }

}

}

