
using pykos.Util;
using pykos.Gui;

using System;
using UnityEngine;

namespace pykos
{

[KSPAddon(KSPAddon.Startup.MainMenu, true)]
public class Main : MonoBehaviour
{

  private static GuiManager guiManager = null;

  static Main ()
    {
      Logging.info("This is pyKOS!");
      Logging.debug("starting pyKOS initialization phase");
      
      Logging.debug("  initializing GuiManager...");
      guiManager = new GuiManager();
      
      Logging.debug("pyKOS initialization phase complete");
    }

  public void Awake ()
    {
      guiManager.setup();
    }

  /* these are kept for reference - Still learning about MonoBehaviour and KSP */
  /*
    public void Start () { }
    public void Update () { }
    public void FixedUpdate () { }
    public void OnDestroy () { }
  */

}

}

