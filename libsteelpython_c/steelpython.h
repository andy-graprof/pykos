
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
