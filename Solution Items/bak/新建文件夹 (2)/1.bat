@rem ------传入当前目录------
@pushd "%~dp0"
@rem ------传入当前目录------
@rem ------调用bat------
@call 2.bat '大家好才是真的好'
@rem ------调用bat------
@rem ------延时关闭------
@ping localhost -n 3 >nul
@rem ------延时关闭------
@rem pause暂停