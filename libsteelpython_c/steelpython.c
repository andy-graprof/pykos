
#include "steelpython.h"

#include <Python.h>
#include <stdio.h>

#define __unused __attribute__((unused))

FILE *logfile = NULL;

typedef void(*PythonOutputCallback)(char c);

PythonOutputCallback onOutputCallback;

static PyObject*
pykos_putchar(__unused PyObject *self, PyObject *args)
{
  char out;

  if(!PyArg_ParseTuple(args, "c", &out))
    return NULL;

  onOutputCallback(out);

  Py_RETURN_NONE;
}

static PyMethodDef pykosMethods[] = {
  {"putchar", pykos_putchar, METH_VARARGS, "pass a char of output back upwards"},
  {NULL, NULL, 0, NULL}
};

void
libsteelpython_initialize (
  PythonOutputCallback outputCallback
)
{
  onOutputCallback = outputCallback;

  Py_SetProgramName("steelpython");
  Py_Initialize();

  Py_InitModule("pykos", pykosMethods);

  const char *preamble =
    "import sys\n"
    "import pykos\n"
    "class CatchOutErr:\n"
    "  def init(self):\n"
    "    pass\n"
    "  def write(self, txt):\n"
    "    for c in txt:\n"
    "      pykos.putchar(c)\n"
    "catchOutErr = CatchOutErr()\n"
    "sys.stdout = catchOutErr\n"
    "sys.stderr = catchOutErr\n";

  PyRun_SimpleString(preamble);
}

void
libsteelpython_execute (const char *code)
{
  onOutputCallback('>');
  onOutputCallback('>');
  onOutputCallback('>');
  onOutputCallback(' ');

  const char *c = code;
  while (*c)
    {
      onOutputCallback(*c);
      ++c;
    }

  onOutputCallback('\n');

  PyRun_SimpleString(code);
}
