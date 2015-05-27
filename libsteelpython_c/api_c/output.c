
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

static PykosCallback pykosOutputCallback = NULL;

PyObject*
pykosOutput (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosOutputCallback(out);

  Py_RETURN_NONE;
}

void
pykosOutput_c (char c)
{
  char out[] = { c, '\0' };
  pykosOutputCallback(out);
}

static PykosCallback pykosLoggingDebugCallback = NULL;

PyObject*
pykosLoggingDebug (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingDebugCallback(out);

  Py_RETURN_NONE;
}

static PykosCallback pykosLoggingInfoCallback = NULL;

PyObject*
pykosLoggingInfo (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingInfoCallback(out);

  Py_RETURN_NONE;
}

static PykosCallback pykosLoggingWarningCallback = NULL;

PyObject*
pykosLoggingWarning (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingWarningCallback(out);

  Py_RETURN_NONE;
}

static PykosCallback pykosLoggingErrorCallback = NULL;

PyObject*
pykosLoggingError (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingErrorCallback(out);

  Py_RETURN_NONE;
}

void
pykosLoggingError_c (const char *str)
{
  pykosLoggingErrorCallback(str);
}

static PykosCallback pykosLoggingCriticalCallback = NULL;

PyObject*
pykosLoggingCritical (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingCriticalCallback(out);

  Py_RETURN_NONE;
}

void
output_discoverCallbacks(void)
{
  __check(NULL != (pykosOutputCallback = discovery("PyKOS.Python.Interpreter", "onOutputCallback")));
  
  __check(NULL != (pykosLoggingDebugCallback = discovery("PyKOS.Util.Logging", "debug")));
  __check(NULL != (pykosLoggingInfoCallback = discovery("PyKOS.Util.Logging", "info")));
  __check(NULL != (pykosLoggingWarningCallback = discovery("PyKOS.Util.Logging", "warning")));
  __check(NULL != (pykosLoggingErrorCallback = discovery("PyKOS.Util.Logging", "error")));
  __check(NULL != (pykosLoggingCriticalCallback = discovery("PyKOS.Util.Logging", "critical")));
}