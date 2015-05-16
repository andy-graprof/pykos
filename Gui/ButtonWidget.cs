
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ButtonWidget : Widget
{

  public ButtonWidget (MonoBehaviour _parent) : base(_parent)
    {
      
    }

  override public void redraw ()
    {
      Logging.debug("ButtonWidget redraw");
    }

}
  
}

