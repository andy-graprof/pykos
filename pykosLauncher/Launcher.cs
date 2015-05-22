
/******************************************************************************
 *                    pykos - bringing python to KSP                          *
 *                                                                            *
 *    Copyright (C) 2015  Andreas Grapentin                                   *
 *                                                                            *
 *    This program is free software: you can redistribute it and/or modify    *
 *    it under the terms of the GNU General Public License as published by    *
 *    the Free Software Foundation, either version 3 of the License, or       *
 *    (at your option) any later version.                                     *
 *                                                                            *
 *    This program is distributed in the hope that it will be useful,         *
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of          *
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *
 *    GNU General Public License for more details.                            *
 *                                                                            *
 *    You should have received a copy of the GNU General Public License       *
 *    along with this program.  If not, see <http://www.gnu.org/licenses/>.   *
 ******************************************************************************/

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

}

}

