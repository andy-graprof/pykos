
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
  discover = callback;

  output_discover();

  Py_SetProgramName("pykos");
  Py_Initialize();

  // errno has been polluted by Py_SetProgramName and Py_Initialize
  errno = 0;

  // include current directory in import path
  PyObject *path = PySys_GetObject("path");
  __check(NULL != path);
  PyObject *api = PyString_FromString("./pykos/api");
  __check(NULL != api);
  PyObject *usr = PyString_FromString("./pykos");
  __check(NULL != usr);
  __check(0 == PyList_Insert(path, 0, api));
  __check(0 == PyList_Insert(path, 0, usr));

  __check(NULL != Py_InitModule("_pykosapi", _pykosapi));
  __check(NULL != PyImport_ImportModule("pykos"));
}

void
libsteelpython_execute (const char *code)
{
  pykos_putchar_c('>');
  pykos_putchar_c('>');
  pykos_putchar_c('>');
  pykos_putchar_c(' ');

  const char *c = code;
  while (*c)
    {
      pykos_putchar_c(*c);
      ++c;
    }

  pykos_putchar_c('\n');

  PyRun_SimpleString(code);
}
