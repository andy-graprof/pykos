
from factory import make_method

class Logging:

  def __init__(self):
    self.debug    = make_method("PyKOS.Util.Logging", "debug")
    self.info     = make_method("PyKOS.Util.Logging", "info")
    self.warning  = make_method("PyKOS.Util.Logging", "warning")
    self.error    = make_method("PyKOS.Util.Logging", "error")
    self.critical = make_method("PyKOS.Util.Logging", "critical")
