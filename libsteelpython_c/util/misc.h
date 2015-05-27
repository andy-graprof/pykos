
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

// import shared headers
#include <Python.h>
#include <errno.h>
#include <string.h>
#include <stdarg.h>

// make sure DEBUG is always defined
#ifndef DEBUG
#  define DEBUG 0
#endif

// provide semantic sugar
#ifdef __GNUC__
#  define __unused __attribute__((unused))
#  define __may_fail __attribute__((warn_unused_result))
#  define __format(F, I, S) __attribute__((format(F, I, S)))
#else
#  define __unused
#  define __may_fail
#  define __format(F, I, S)
#endif

// branch prediction
#ifdef __GNUC__
#  define __likely(X)   __builtin_expect((X), 1)
#  define __unlikely(X) __builtin_expect((X), 0)
#else
#  define __likely(X)   (X)
#  define __unlikely(X) (X)
#endif

extern void pykos_logging_error_c(const char *src);

// error printing macros
#define __check(C) \
  do \
    { \
      if (__likely(C)) break; \
      int errnum = errno; \
      if (errnum) \
        { \
          int length = snprintf(NULL, 0, "steelpython:%s:%u: check failed: %s: %s", __FILE__, __LINE__, # C, strerror(errnum)); \
          char *str = malloc(length + 1); \
          snprintf(str, length + 1, "steelpython:%s:%u: check failed: %s: %s", __FILE__, __LINE__, # C, strerror(errnum)); \
          pykos_logging_error_c(str); \
          free(str); \
        } \
      else \
        { \
          int length = snprintf(NULL, 0, "steelpython:%s:%u: check failed: %s", __FILE__, __LINE__, # C); \
          char *str = malloc(length + 1); \
          snprintf(str, length + 1, "steelpython:%s:%u: check failed: %s", __FILE__, __LINE__, # C); \
          pykos_logging_error_c(str); \
          free(str); \
        } \
      errno = errnum; \
    } \
  while (0)
