
using pykos.Gui;
using pykos.Util;

using System;
using System.Linq;
using UnityEngine;

namespace pykos
{

public class Window : MonoBehaviour
{

  protected Rect dimensions;
  protected string title = null;
  protected int windowId;

  protected GUIStyle style = null;

  protected bool visible = false;
  protected GameScenes[] scenes = null;

  public Window (string _title, float left, float top, float width, float height, GameScenes[] _scenes = null)
    {
      dimensions = new Rect(left, top, width, height);
      title = _title;
      scenes = _scenes;
      
      windowId = GuiManager.windowList.Add(title);
      
      style = new GUIStyle(HighLogic.Skin.window);      
    }
    
  public void show ()
    {
      visible = true;
    }
    
  public void hide ()
    {
      visible = false;
    }

  public void register ()
    {
      Logging.debug("registering ConsoleWindow");
      RenderingManager.AddToPostDrawQueue(0, onDraw);
    }
    
  public void release ()
    {
      Logging.debug("releasing ConsoleWindow");
      RenderingManager.RemoveFromPostDrawQueue(0, onDraw);
    }

  private void onDraw ()
    {
      if (!visible || scenes == null || !(scenes.Contains(HighLogic.LoadedScene)))
        return;
        
      dimensions = GUI.Window(windowId, dimensions, redraw, title, style);
    }
    
  virtual protected void redraw (int windowId)
    {
      GUI.DragWindow();
    }
}

}

