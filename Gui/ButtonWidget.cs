
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

