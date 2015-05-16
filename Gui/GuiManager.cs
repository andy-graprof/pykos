
using pykos.Util;

using System;
using System.Collections;

namespace pykos.Gui
{

internal class GuiManager
{

  public static GuiManager instance { get; set; }

  public static void initialize ()
    {
      Logging.debug("creating singleton instance of GuiManager");
      instance = new GuiManager();
    }

  public static ArrayList windowList = new ArrayList();

  private ToolbarButton toolbarButton = null;
  private ConsoleWindow consoleWindow = null;

  private GuiManager ()
    {
      toolbarButton = new ToolbarButton();
      consoleWindow = new ConsoleWindow();
      
      Logging.debug("registering GuiManager Events");
      GameEvents.onGUIApplicationLauncherReady.Add(onGUIApplicationLauncherReady);
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
  
  public void toggleConsoleWindow ()
    {
      consoleWindow.toggleVisibility();
    }
  
}
  
}

