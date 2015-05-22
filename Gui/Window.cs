
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

  public Window (float left, float top, float width, float height, string _title, GameScenes[] _scenes = null)
    {
      dimensions = new Rect(left, top, width, height);
      title = _title;
      scenes = _scenes;

      windowId = GuiManager.windowList.Add(title);

      style = new GUIStyle(HighLogic.Skin.window);
    }

  public float width { get { return dimensions.width; } }
  public float height { get { return dimensions.height; } }

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
      RenderingManager.AddToPostDrawQueue(0, onDraw);
    }

  public void release ()
    {
      RenderingManager.RemoveFromPostDrawQueue(0, onDraw);
    }

  private void onDraw ()
    {
      if (!visible || scenes == null || !(scenes.Contains(HighLogic.LoadedScene)))
        return;

      dimensions = GUI.Window(windowId, dimensions, onDrawWindow, title, style);
    }

  private void onDrawWindow (int windowId)
    {
      redraw();

      GUI.DragWindow();
    }

  virtual protected void redraw () { }

}

}

