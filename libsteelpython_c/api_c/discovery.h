
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

typedef const char*(*PykosCallback)(const char *args);
typedef PykosCallback(*PykosDiscoveryCallback)(const char *type, const char *method);

extern PykosDiscoveryCallback discover;

/* _pykosapi.discover
 *
 * Try and discover a function object from the csharp environment
 *
 * params:
 *   type - a string representing a type
 *   method - a string representing a method in the given type
 *
 * returns:
 *   a capsule to be passed to _pykosapi.call on success, NULL otherwise
 */
PyObject* pykos_discover (PyObject *self, PyObject *args);

/* _pykosapi.call
 *
 * Execute a function discovered by _pykosapi.discover
 *
 * params:
 *   o - a capsule object reurned by _pykosapi.discover
 *   a - a string representing the arguments to the function
 *
 * returns:
 *   a string representing the result of the call
 */
PyObject* pykos_call (PyObject *self, PyObject *args);
