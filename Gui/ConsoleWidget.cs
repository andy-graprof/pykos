
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWidget : Widget
{

  public ConsoleWidget (MonoBehaviour _parent) : base(_parent)
    {
      
    }

  override public void redraw ()
    {
      Logging.debug("ConsoleWidget redraw");
    }

}

}

