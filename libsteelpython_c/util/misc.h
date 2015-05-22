
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

extern void pykosLoggingError_c(const char *src);

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
          pykosLoggingError_c(str); \
        } \
      else \
        { \
          int length = snprintf(NULL, 0, "steelpython:%s:%u: check failed: %s", __FILE__, __LINE__, # C); \
          char *str = malloc(length + 1); \
          snprintf(str, length + 1, "steelpython:%s:%u: check failed: %s", __FILE__, __LINE__, # C); \
          pykosLoggingError_c(str); \
        } \
      errno = errnum; \
    } \
  while (0)
