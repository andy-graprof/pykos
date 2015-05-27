
import _pykosapi
import sys

class CatchOutErr:
  def write(self, txt):
    for c in txt:
      _pykosapi.putchar(c)

catchOutErr = CatchOutErr()
sys.stdout = catchOutErr
sys.stderr = catchOutErr

