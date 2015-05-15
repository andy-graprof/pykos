
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWindow
{

  private Rect shape = new Rect(0, 0, 320, 240);
  private GUIStyle style = null;
  private bool visible = false;

  public ConsoleWindow ()
    {
      style = new GUIStyle(HighLogic.Skin.window);
    }

  public void register ()
    {
      Logging.debug("registering ConsoleWindow");
      RenderingManager.AddToPostDrawQueue(0, onDraw);
    }
    
  public void release ()
    {
      Logging.debug("releasing ConsoleWindow");
    }

  public void toggleVisibility ()
    {
      visible = !visible;
    }

  private bool isValidGameScene ()
    {
      GameScenes current = HighLogic.LoadedScene;
      return
           current == GameScenes.FLIGHT
        || current == GameScenes.SPACECENTER
        || current == GameScenes.EDITOR
        || current == GameScenes.TRACKSTATION;
    }

  private void onDraw ()
    {
      if (!visible || !isValidGameScene())
        return;
        
      shape = GUI.Window(3004001, shape, drawWindow, "pyKOS", style);
    }

  private void drawWindow (int windowId)
    {
      GUILayout.BeginHorizontal();
      GUILayout.Label("ABC-");
      GUILayout.Label("123");
      GUILayout.EndHorizontal();
            
      GUI.DragWindow();    
    }

}

}

