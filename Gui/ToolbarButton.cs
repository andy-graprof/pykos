
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

public delegate void ToolbarButtonCallback ();

internal class ToolbarButton
{

  private ApplicationLauncherButton button = null;

  private const ApplicationLauncher.AppScenes appScenes =
      ApplicationLauncher.AppScenes.FLIGHT
    | ApplicationLauncher.AppScenes.SPH
    | ApplicationLauncher.AppScenes.VAB
    | ApplicationLauncher.AppScenes.MAPVIEW
    | ApplicationLauncher.AppScenes.SPACECENTER;

  private Texture2D texture = null;

  private ToolbarButtonCallback callback = null;

  public ToolbarButton (ToolbarButtonCallback _callback)
    {
      callback = _callback;
      texture = GameDatabase.Instance.GetTexture("pykos/textures/toolbar-button",false);
    }

  public void register ()
    {
      if (button != null)
        return;

      button = ApplicationLauncher.Instance.AddModApplication(
        onClick,
        onClick,
        null,
        null,
        null,
        null,
        appScenes,
        texture
      );
    }

  public void release ()
    {
      if (button == null)
        return;

      ApplicationLauncher.Instance.RemoveModApplication(button);
      button = null;
    }

  private void onClick ()
    {
      Logging.debug("handling ToolbarButton Event: onClick");
      callback();
    }

}

}

