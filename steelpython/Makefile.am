
AUTOMAKE_OPTIONS = subdir-objects
ACLOCAL_AMFLAGS = -I m4

## libraries

lib_LTLIBRARIES = steelpython/libsteelpython.la

steelpython_libsteelpython_la_SOURCES = \
  steelpython/steelpython.c steelpython/steelpython.h

steelpython_libsteelpython_la_CPPFLAGS = $(PYTHON_CPPFLAGS)
steelpython_libsteelpython_la_LDFLAGS = $(PYTHON_LDFLAGS) $(PYTHON_EXTRA_LDFLAGS)
steelpython_libsteelpython_la_LIBADD = $(PYTHON_EXTRA_LIBS)
