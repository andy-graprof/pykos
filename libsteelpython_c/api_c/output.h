
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

#include "api_c/discovery.h"

/* _pykosapi.putchar
 *
 * This function is used for printing the output of pythong scripts in the
 * pykos console window rendered into KSP.
 *
 * params:
 *   c - a character to be printed in the KSP console window
 */
PyObject* pykos_putchar (PyObject *self, PyObject *args);

/* similar to _pykosapi.putchar, but available from the c context
 *
 * params:
 *   c - a character to be printed in the KSP console window
 */
void pykos_putchar_c (char c);

/* discover the callbacks for the functions in the output module
 */
void output_discover (void);