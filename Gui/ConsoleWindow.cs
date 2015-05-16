
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWindow : Window
{

  private ConsoleWidget consoleWidget = null;
  private ButtonWidget closeButtonWidget = null;

  public ConsoleWindow () : base("pyKOS", 60, 50, 320, 240, 
      new GameScenes[] { GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.EDITOR, GameScenes.TRACKSTATION })
    {
      consoleWidget = new ConsoleWidget(this);
      closeButtonWidget = new ButtonWidget(this);
    }

  public void toggleVisibility ()
    {
      if (visible) hide(); else show();
    }

  override protected void redraw (int windowId)
    {
      consoleWidget.redraw();
      closeButtonWidget.redraw();
    
      GUI.DragWindow(); 
    }

}

}

