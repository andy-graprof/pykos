
using pykosLauncher.Util;

using System;
using System.Reflection;
using UnityEngine;

namespace pykosLauncher
{

[KSPAddon(KSPAddon.Startup.MainMenu, true)]
public class Launcher : MonoBehaviour
{

  private const string path = "pykos/libs/";

  private Assembly pykos;
  private Type pykosType;

  private MethodInfo awake = null;

  public void Awake ()
    {
      Logging.info("This is the pyKOS Launcher!");
      Logging.info("attempting to load pyKOS assembly");
       
      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(onResolveAssembly);
      AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(onLoadAssembly);
      
      try
        {
          pykos = Assembly.Load("pykos");
        }
      catch (Exception e)
        {
          Logging.error("failed to load pykos assembly");
          Logging.error(e.ToString());
          return;
        }
        
      Logging.info("attempting to extract reference to PyKOS class");
      
      try
        {
          pykosType = pykos.GetType("pykos.PyKOS");
        }
      catch (Exception e)
        {
          Logging.error("failed to extract reference to PyKOS class");
          Logging.error(e.ToString());
          return;
        }
        
      Logging.info("attempting to extract method references");
      
      try
        {
          awake = pykosType.GetMethod("Awake", BindingFlags.Public | BindingFlags.Static);
        }
      catch (Exception e)
        {
          Logging.error("failed to extract method references");
          Logging.error(e.ToString());
          return;
        }
        
      Logging.info("attempting to hand control over to PyKOS");
      
      try
        {
          awake.Invoke(null, null);
        }
      catch (Exception e)
        {
          Logging.error("failed to hand control over to PyKOS");
          Logging.error(e.ToString());
          return;
        }
    }

  private static Assembly onResolveAssembly (object sender, ResolveEventArgs args)
    {
      Logging.debug("resolving assembly: '" + args.Name + "'");
      
      try 
        {
          return Assembly.LoadFrom(path + args.Name + ".dll");        
        } 
      catch (Exception e)
        {
          Logging.error(e.ToString());
          return null;
        }
    }
    
  private static void onLoadAssembly (object sender, AssemblyLoadEventArgs args)
    {
      Logging.debug("loaded assembly: '" + args.LoadedAssembly.FullName + "' from:" + args.LoadedAssembly.Location);
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

