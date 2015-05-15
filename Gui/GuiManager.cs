
using pykos.Util;

using System;

namespace pykos.Gui
{

internal class GuiManager
{

  private ToolbarButton toolbarButton = null;

  public GuiManager ()
    {
      toolbarButton = new ToolbarButton();
    }
    
  public void setup ()
    {
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
  
}
  
}

