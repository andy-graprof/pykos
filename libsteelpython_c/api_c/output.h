
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
