
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWidget : Widget
{

  private Rect dimensions;

  public ConsoleWidget (MonoBehaviour _parent, float left, float top, float width, float height) : base(_parent)
    {
      dimensions = new Rect(left, top, width, height);
    }

  override public void redraw ()
    {
      Texture2D texture = new Texture2D(1, 1);
      texture.SetPixel(0,0,Color.green);
      texture.Apply();
      GUI.skin.box.normal.background = texture;
      GUI.Box(dimensions, GUIContent.none);
    }

}

}

