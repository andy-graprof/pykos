
using pykos.Util;

using System;
using System.Collections;

namespace pykos.Gui
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

