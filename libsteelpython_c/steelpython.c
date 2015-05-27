
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

#include "steelpython.h"

void
libsteelpython_initialize (PykosDiscoveryCallback callback)
{
  discovery = callback;

  output_discoverCallbacks();

  Py_SetProgramName("pykos");
  Py_Initialize();

  // errno has been polluted by Py_SetProgramName and Py_Initialize
  errno = 0;

  // get reference to __main__ module
  PyObject *mod_main = PyImport_AddModule("__main__");
  __check(NULL != mod_main);

  // import and get references to used modules
  PyObject *mod_sys = PyImport_ImportModule("sys");
  __check(NULL != mod_sys);

  // create and get references to provided modules
  PyObject *mod_pykosapi = Py_InitModule("_pykosapi", _pykosapi);
  __check(NULL != mod_pykosapi);

  // add referenced modules to __main__
  __check(0 == PyModule_AddObject(mod_main, "_pykosapi", mod_pykosapi));
  __check(0 == PyModule_AddObject(mod_main, "sys", mod_sys));

  // create class for stdout / stderr capture

  // capture stdout / stderr
  const char *preamble =
    "class CatchOutErr:\n"
    "  def write(self, txt):\n"
    "    for c in txt:\n"
    "      _pykosapi.pykosOutput(str(c))\n"
    "catchOutErr = CatchOutErr()\n"
    "sys.stdout = catchOutErr\n"
    "sys.stderr = catchOutErr\n";

  PyRun_SimpleString(preamble);
}

void
libsteelpython_execute (const char *code)
{
  pykosOutput_c('>');
  pykosOutput_c('>');
  pykosOutput_c('>');
  pykosOutput_c(' ');

  const char *c = code;
  while (*c)
    {
      pykosOutput_c(*c);
      ++c;
    }

  pykosOutput_c('\n');

  PyRun_SimpleString(code);
}
