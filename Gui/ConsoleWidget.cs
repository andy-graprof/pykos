
using pykos.Util;
using SteelPython;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWidget : Widget
{

  private Rect dimensions_out;
  private Rect dimensions_in;
  private string input = "";    
  private Vector2 scroll = new Vector2(0, Mathf.Infinity);

  private const float inputEditHeight = 20;

  public ConsoleWidget (MonoBehaviour _parent, float left, float top, float width, float height) : base(_parent)
    {
      dimensions_out = new Rect(left, top, width, height - inputEditHeight);
      dimensions_in = new Rect(left, top + height - inputEditHeight, width, inputEditHeight);
    }

  override public void redraw ()
    {
      if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
        {
          Interpreter.execute(input);
          input = "";
          scroll = new Vector2(0, Mathf.Infinity);
        }
    
      GUILayout.BeginArea(dimensions_out);
      scroll = GUILayout.BeginScrollView(scroll);
      GUILayout.TextArea(Interpreter.output, GUILayout.MinHeight(dimensions_out.height));
      GUILayout.EndScrollView();
      GUILayout.EndArea();
      
      input = GUI.TextArea(dimensions_in, input);
    }

}

}

