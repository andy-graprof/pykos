
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

TPykosOutputCallback pykosOutputCallback = NULL;

PyObject*
pykosOutput (__unused PyObject *self, PyObject *args)
{
  char out;

  if(!PyArg_ParseTuple(args, "c", &out))
    return NULL;

  pykosOutputCallback(out);

  Py_RETURN_NONE;
}

TPykosLoggingCallback pykosLoggingDebugCallback = NULL;

PyObject*
pykosLoggingDebug (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingDebugCallback(out);

  Py_RETURN_NONE;
}

TPykosLoggingCallback pykosLoggingInfoCallback = NULL;

PyObject*
pykosLoggingInfo (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingInfoCallback(out);

  Py_RETURN_NONE;
}

TPykosLoggingCallback pykosLoggingWarningCallback = NULL;

PyObject*
pykosLoggingWarning (__unused PyObject *self, PyObject *args)
{
  const char *out;

  if(!PyArg_ParseTuple(args, "s", &out))
    return NULL;

  pykosLoggingWarningCallback(out);

  Py_RETURN_NONE;
}

TPykosLoggingCallback pykosLoggingErrorCallback = NULL;

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

TPykosLoggingCallback pykosLoggingCriticalCallback = NULL;

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
libsteelpython_registerOutputCallbacks(
  TPykosOutputCallback  _pykosOutputCallback,
  TPykosLoggingCallback _pykosLoggingDebugCallback,
  TPykosLoggingCallback _pykosLoggingInfoCallback,
  TPykosLoggingCallback _pykosLoggingWarningCallback,
  TPykosLoggingCallback _pykosLoggingErrorCallback,
  TPykosLoggingCallback _pykosLoggingCriticalCallback)
{
  pykosOutputCallback           = _pykosOutputCallback;
  pykosLoggingDebugCallback     = _pykosLoggingDebugCallback;
  pykosLoggingInfoCallback      = _pykosLoggingInfoCallback;
  pykosLoggingWarningCallback   = _pykosLoggingWarningCallback;
  pykosLoggingErrorCallback     = _pykosLoggingErrorCallback;
  pykosLoggingCriticalCallback  = _pykosLoggingCriticalCallback;
}