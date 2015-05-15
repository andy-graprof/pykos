
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

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
  
  public ToolbarButton ()
    {
      texture = GameDatabase.Instance.GetTexture("pykos/textures/toolbar-button",false);
    }

  public void register ()
    {
      Logging.debug("registering ToolbarButton");
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
      Logging.debug("releasing ToolbarButton");
      ApplicationLauncher.Instance.RemoveModApplication(button);
    }

  private void onClick ()
    {
      Logging.debug("handling ToolbarButton Event: onClick");
      GuiManager.instance.toggleConsoleWindow();
    }

}
  
}

