
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