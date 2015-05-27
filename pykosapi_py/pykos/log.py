
from factory import make_method

class Logging:

  def __init__(self):
    self.debug    = make_method("PyKOS.Util.Logging", "debug_json")
    self.info     = make_method("PyKOS.Util.Logging", "info_json")
    self.warning  = make_method("PyKOS.Util.Logging", "warning_json")
    self.error    = make_method("PyKOS.Util.Logging", "error_json")
    self.critical = make_method("PyKOS.Util.Logging", "critical_json")
