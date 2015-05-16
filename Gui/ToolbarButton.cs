
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

