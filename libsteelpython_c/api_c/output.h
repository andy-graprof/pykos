
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

/* callback types */
typedef void(*TPykosOutputCallback)(char c);
typedef void(*TPykosLoggingCallback)(const char *str);

/* _pykosapi.pykosOutput
 *
 * This function is used for printing the output of pythong scripts in the
 * pykos console window rendered into KSP.
 *
 * params:
 *   c - a character to be printed in the KSP console window
 */
extern TPykosOutputCallback pykosOutputCallback;
PyObject* pykosOutput (PyObject *self, PyObject *args);


/* _pykosapi.pykosLoggingDebug
 *
 * This function is used for writing to the pykos logfile with the severity
 * level DEBUG.
 *
 * params:
 *   str - a string to be logged in pykos.log
 */
extern TPykosLoggingCallback pykosLoggingDebugCallback;
PyObject *pykosLoggingDebug (PyObject *self, PyObject *args);

/* _pykosapi.pykosLoggingInfo
 *
 * This function is used for writing to the pykos logfile with the severity
 * level INFO.
 *
 * params:
 *   str - a string to be logged in pykos.log
 */
extern TPykosLoggingCallback pykosLoggingInfoCallback;
PyObject *pykosLoggingInfo (PyObject *self, PyObject *args);

/* _pykosapi.pykosLoggingWarning
 *
 * This function is used for writing to the pykos logfile with the severity
 * level WARNING.
 *
 * params:
 *   str - a string to be logged in pykos.log
 */
extern TPykosLoggingCallback pykosLoggingWarningCallback;
PyObject *pykosLoggingWarning (PyObject *self, PyObject *args);

/* _pykosapi.pykosLoggingError
 *
 * This function is used for writing to the pykos logfile with the severity
 * level ERROR.
 *
 * params:
 *   str - a string to be logged in pykos.log
 */
extern TPykosLoggingCallback pykosLoggingErrorCallback;
PyObject *pykosLoggingError (PyObject *self, PyObject *args);

/* _pykosapi.pykosLoggingCritical
 *
 * This function is used for writing to the pykos logfile with the severity
 * level CRITICAL.
 *
 * params:
 *   str - a string to be logged in pykos.log
 */
extern TPykosLoggingCallback pykosLoggingCriticalCallback;
PyObject *pykosLoggingCritical (PyObject *self, PyObject *args);
