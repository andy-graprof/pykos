
using pykos.Util;
using pykos.Gui;

using System;
using UnityEngine;

namespace pykos
{

[KSPAddon(KSPAddon.Startup.MainMenu, true)]
public class Main : MonoBehaviour
{

  static Main ()
    {
      Logging.info("This is pyKOS!");
      Logging.debug("starting pyKOS initialization phase");
      
      GuiManager.initialize();
      
      Logging.debug("pyKOS initialization phase complete");
    }

  /* these are kept for reference - Still learning about MonoBehaviour and KSP */
  /*
    public void Awake () { }
    public void Start () { }
    public void Update () { }
    public void FixedUpdate () { }
    public void OnDestroy () { }
  */

}

}

