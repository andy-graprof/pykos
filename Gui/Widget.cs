
using pykos.Util;

using System;
using UnityEngine;

namespace pykos.Gui
{

public class Widget
{

  protected MonoBehaviour parent = null;

  public Widget (MonoBehaviour _parent)
    {
      parent = _parent;
    }

  virtual public void redraw ()
    {
    
    }

}

}

