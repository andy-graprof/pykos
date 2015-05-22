
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public delegate void ButtonWidgetCallback ();

public class ButtonWidget : Widget
{

  private Rect dimensions;
  private string caption = null;
  private ButtonWidgetCallback callback = null;

  public ButtonWidget (MonoBehaviour _parent, float left, float top, float width, float height, string _caption, ButtonWidgetCallback _callback) : base(_parent)
    {
      dimensions = new Rect(left, top, width, height);
      caption = _caption;

      callback = _callback;
    }

  override public void redraw ()
    {
      if (GUI.Button(dimensions, caption))
        callback();
    }

}

}

