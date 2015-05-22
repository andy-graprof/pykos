
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

using PyKOS.Util;

using System;
using System.Collections;

namespace PyKOS.Gui
{

internal class GuiManager
{

  public static GuiManager instance { get; set; }

  public static ArrayList windowList = new ArrayList();

  public static void initialize ()
    {
      Logging.debug("initializing GuiManager");
      instance = new GuiManager();
    }

  private ToolbarButton toolbarButton = null;
  private ConsoleWindow consoleWindow = null;

  private GuiManager ()
    {
      toolbarButton = new ToolbarButton(onToolbarButtonPressed);
      consoleWindow = new ConsoleWindow(50, 50, 400, 300, "pyKOS");

      Logging.debug("registering GuiManager Event: onGUIApplicationLauncherReady");
      GameEvents.onGUIApplicationLauncherReady.Add(onGUIApplicationLauncherReady);
      Logging.debug("registering GuiManager Event: onGUIApplicationLauncherDestroyed");
      GameEvents.onGUIApplicationLauncherDestroyed.Add(onGUIApplicationLauncherDestroyed);
    }

  private void onGUIApplicationLauncherReady ()
    {
      Logging.debug("handling GuiManager Event: onGUIApplicationLauncherReady");
      toolbarButton.register();
      consoleWindow.register();
    }

  private void onGUIApplicationLauncherDestroyed ()
    {
      Logging.debug("handling GuiManager Event: onGUIApplicationLauncherDestroyed");
      toolbarButton.release();
      consoleWindow.release();
    }

  public void onToolbarButtonPressed ()
    {
      consoleWindow.toggleVisibility();
    }

}

}

