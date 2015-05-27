
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

#include "output.h"

static PykosCallback pykos_putchar_callback = NULL;

PyObject*
pykos_putchar (__unused PyObject *self, PyObject *args)
{
  char out;

  if(!PyArg_ParseTuple(args, "c", &out))
    return NULL;

  pykos_putchar_c(out);

  Py_RETURN_NONE;
}

void
pykos_putchar_c (char c)
{
  char out[] = { c, '\0' };
  pykos_putchar_callback(out);
}

static PykosCallback pykos_logging_error_callback = NULL;

void
pykos_logging_error_c (const char *str)
{
  pykos_logging_error_callback(str);
}

void
output_discover(void)
{
  __check(NULL != (pykos_putchar_callback = discover("PyKOS.Python.Interpreter", "onPutcharCallback")));

  __check(NULL != (pykos_logging_error_callback = discover("PyKOS.Util.Logging", "error")));
}