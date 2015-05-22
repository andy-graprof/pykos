
/******************************************************************************
 *                    pykos - bringing python to KSP                          *
 *                                                                            *
 *    Copyright (C) 2015  Andreas Grapentin                                   *
 *                                                                            *
 *    This program is free software: you can redistribute it and/or modify    *
 *    it under the terms of the GNU General Public License as published by    *
 *    the Free Software Foundation, either version 3 of the License, or       *
 *    (at your option) any later version.                                     *
 *                                                                            *
 *    This program is distributed in the hope that it will be useful,         *
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of          *
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *
 *    GNU General Public License for more details.                            *
 *                                                                            *
 *    You should have received a copy of the GNU General Public License       *
 *    along with this program.  If not, see <http://www.gnu.org/licenses/>.   *
 ******************************************************************************/

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

