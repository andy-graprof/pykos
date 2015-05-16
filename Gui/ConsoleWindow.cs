
using pykos.Util;

using System;
using System.Collections;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWindow : Window
{

  private ArrayList children = new ArrayList();

  public ConsoleWindow (float left, float top, float width, float height, string title) : base(left, top, width, height, title, 
      new GameScenes[] { GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.EDITOR, GameScenes.TRACKSTATION })
    {
      float borderMargin = 5;
      float titleMargin = 20;
      float closeButtonWidth = 100;
      float closeButtonHeight = 20;    

      children.Add(new ConsoleWidget(this,
        borderMargin,
        titleMargin + borderMargin,
        width - borderMargin - borderMargin,
        height - titleMargin - borderMargin - borderMargin - closeButtonHeight - borderMargin
      ));
      children.Add(new ButtonWidget(this,
        width - borderMargin - closeButtonWidth, 
        height - borderMargin - closeButtonHeight,
        closeButtonWidth,
        closeButtonHeight,
        "Close",
        onCloseButtonClicked
      ));
    }

  public void toggleVisibility ()
    {
      if (visible) hide(); else show();
    }

  override protected void redraw ()
    {
      foreach (Widget child in children)
        child.redraw();
    }
    
  private void onCloseButtonClicked ()
    {
      hide();
    }

}

}

