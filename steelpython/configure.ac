
AC_INIT([steelpython], [0.1], [andreas@grapentin.org])
AC_CONFIG_SRCDIR([steelpython/steelpython.h])
AC_CONFIG_HEADERS([config.h])
AC_CONFIG_AUX_DIR([scripts])
AC_CONFIG_MACRO_DIRS([m4])

AM_INIT_AUTOMAKE([-Wall -Werror foreign])

AC_PROG_CC
AM_PROG_AR

AX_PYTHON_DEVEL([>='2.6'])

LT_INIT

AC_CONFIG_FILES([
  Makefile
])

AC_OUTPUT
