
using pykos.Util;

using System;
using System.Collections;
using UnityEngine;

namespace pykos.Gui
{

public class ConsoleWindow : Window
{

  private ArrayList children = new ArrayList();

  private const float borderMargin = 5;
  private const float titleMargin = 20;
  private const float closeButtonWidth = 100;
  private const float closeButtonHeight = 20;

  public ConsoleWindow (float left, float top, float width, float height, string title) : base(left, top, width, height, title,
      new GameScenes[] { GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.EDITOR, GameScenes.TRACKSTATION })
    {
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

