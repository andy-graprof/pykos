
using pykos.Util;
using pykos.Gui;
using SteelPython;

using System;
using UnityEngine;

namespace pykos
{

[KSPAddon(KSPAddon.Startup.MainMenu, true)]
public class Main : MonoBehaviour
{

  public void Awake ()
    {
      Logging.info("This is pyKOS!");
      Logging.debug("starting pyKOS initialization phase");
      
      GuiManager.initialize();
      Interpreter.initialize("pyKOS");
      
      Logging.debug("pyKOS initialization phase complete");
    }

  public void Destroy ()
    {
      Logging.info("pyKOS shutting down");
      
      Interpreter.finalize();
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

