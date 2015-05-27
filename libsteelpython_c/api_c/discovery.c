
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

#include "discovery.h"

PykosDiscoveryCallback discover = NULL;

PyObject*
pykos_discover (__unused PyObject *self, PyObject *args)
{
  const char *type;
  const char *method;

  if(!PyArg_ParseTuple(args, "ss", &type, &method))
    return NULL;

  void *fptr = discover(type, method);

  return PyCapsule_New(fptr, NULL, NULL);
}

PyObject*
pykos_call (__unused PyObject *self, PyObject *args)
{
  PyObject *o;
  const char *a;

  if(!PyArg_ParseTuple(args, "Os", &o, &a))
    return NULL;

  PykosCallback fptr = PyCapsule_GetPointer(o, NULL);

  const char *res = fptr(a);
  return PyString_FromString(res ? res : "");
}
