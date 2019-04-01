IF "%1"=="" GOTO help

REM 2011.5.12 Star Xu add remark
REM 2011.5.16 Star Xu accept UNC mode
REM 2011.5.19 Star Xu accept parameter with double-quotation

IF "%1%" == "UNC" (
  PUSHD %2
  CALL InstallVerWatch.bat LOC %3 %4
  POPD
  EXIT
)

SET currentdir=%CD%
SET installpath=%~2
SET updradepath=%~2\upgrade
SET removepath=%~3

IF EXIST %updradepath% RD %updradepath% /S /Q
MD %updradepath%
@REM Cabarc.exe -p -o X CaeVerWatch.cab *.* %updradepath%\
CVWSetup -d%updradepath%\ -s
CD /D %installpath%

IF EXIST dt_uninstall.bat CALL dt_uninstall.bat
COPY %updradepath%\*.* /Y
CALL dt_install.bat
RD %updradepath% /S /Q
GOTO exit

:help
ECHO InstallVerWatch InstallPath

:exit