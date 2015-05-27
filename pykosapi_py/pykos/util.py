
import _pykosapi

log_info_callback = None
def log_info(str):
  _pykosapi.call(log_info_callback, str)

log_info_callback = _pykosapi.discover("PyKOS.Util.Logging", "info")
