
import _pykosapi

import json

def make_method(typename, methodname):
  pykos_callback = _pykosapi.discover(typename, methodname)
  def function(*args):
    return json.loads(_pykosapi.call(pykos_callback, json.dumps(args)))
  return function
