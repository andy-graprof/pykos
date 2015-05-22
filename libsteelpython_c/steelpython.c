
#include "steelpython.h"

void
libsteelpython_initialize (void)
{
  Py_SetProgramName("pykos");
  Py_Initialize();

  // errno has been polluted by Py_SetProgramName and Py_Initialize
  errno = 0;

  // get reference to __main__ module
  PyObject *mod_main = PyImport_AddModule("__main__");
  __check(NULL != mod_main);
  
  // import and get references to used modules
  PyObject *mod_sys = PyImport_ImportModule("sys");
  __check(NULL != mod_sys);

  // create and get references to provided modules
  PyObject *mod_pykosapi = Py_InitModule("_pykosapi", _pykosapi);
  __check(NULL != mod_pykosapi);

  // add referenced modules to __main__
  __check(0 == PyModule_AddObject(mod_main, "_pykosapi", mod_pykosapi));
  __check(0 == PyModule_AddObject(mod_main, "sys", mod_sys));

  // create class for stdout / stderr capture

  // capture stdout / stderr
  const char *preamble =
    "class CatchOutErr:\n"
    "  def write(self, txt):\n"
    "    for c in txt:\n"
    "      _pykosapi.pykosOutput(c)\n"
    "catchOutErr = CatchOutErr()\n"
    "sys.stdout = catchOutErr\n"
    "sys.stderr = catchOutErr\n";

  PyRun_SimpleString(preamble);
}

void
libsteelpython_execute (const char *code)
{
  pykosOutputCallback('>');
  pykosOutputCallback('>');
  pykosOutputCallback('>');
  pykosOutputCallback(' ');

  const char *c = code;
  while (*c)
    {
      pykosOutputCallback(*c);
      ++c;
    }

  pykosOutputCallback('\n');

  PyRun_SimpleString(code);
}
