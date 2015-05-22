
using pykos.Util;
using pykos.Python;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWidget : Widget
{

  private Rect dimensions;
  private string input = "";
  private Vector2 scroll = new Vector2(0, Mathf.Infinity);

  private const float inputEditHeight = 20;

  public ConsoleWidget (MonoBehaviour _parent, float left, float top, float width, float height) : base(_parent) 
    { 
      dimensions = new Rect(left, top, width, height);
    }

  override public void redraw ()
    {
      if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
        {
          Interpreter.execute(input);
          input = "";
          scroll = new Vector2(0, Mathf.Infinity);
          Event.current.Use();
        }

      GUILayout.BeginArea(dimensions);
      GUILayout.BeginVertical();
      scroll = GUILayout.BeginScrollView(scroll, GUILayout.ExpandHeight(true));
      GUILayout.TextArea(Interpreter.output, GUILayout.ExpandHeight(true));
      GUILayout.EndScrollView();

      GUILayout.BeginHorizontal();
      GUILayout.Label(">>>", GUILayout.ExpandWidth(false));
      input = GUILayout.TextArea(input, GUILayout.ExpandWidth(true));
      GUILayout.EndHorizontal();
      GUILayout.EndVertical();
      GUILayout.EndArea();
    }

}

}

