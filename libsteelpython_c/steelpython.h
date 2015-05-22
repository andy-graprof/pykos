
#pragma once

#include "util/misc.h"

#include "api_c/output.h"

static PyMethodDef _pykosapi[] = {

  // output callbacks
  {"pykosOutput",           pykosOutput,            METH_VARARGS, "pass a char of output back upwards"},
  {"pykosLoggingDebgug",    pykosLoggingDebug,      METH_VARARGS, "Log a message of severity DEBUG"},
  {"pykosLoggingInfo",      pykosLoggingInfo,       METH_VARARGS, "Log a message of severity INFO"},
  {"pykosLoggingWarning",   pykosLoggingWarning,    METH_VARARGS, "Log a message of severity WARNING"},
  {"pykosLoggingError",     pykosLoggingError,      METH_VARARGS, "Log a message of severity ERROR"},
  {"pykosLoggingCritical",  pykosLoggingCritical,   METH_VARARGS, "Log a message of severity Critical"},
  
  // end of callbacks
  {NULL, NULL, 0, NULL}
};
