
using pykos.Util;

using System;

namespace pykos.Gui
{

internal class GuiManager
{

  public static GuiManager instance { get; set; }

  public static void initialize ()
    {
      instance = new GuiManager();
    }

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
    }

  private void onGUIApplicationLauncherDestroyed ()
    {
      Logging.debug("handling GuiManager Event: onGUIApplicationLauncherDestroyed");
      toolbarButton.release();
    }
  
  public void toggleConsoleWindow ()
    {
      consoleWindow.toggleVisibility();
    }
  
}
  
}

