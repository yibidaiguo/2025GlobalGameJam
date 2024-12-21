set WORKSPACE=..

set LUBAN_DLL=%WORKSPACE%\Tools\Luban\Luban.dll
set CONF_ROOT=%WORKSPACE%\DataTables

dotnet %LUBAN_DLL% ^
    -t all ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=%WORKSPACE%\..\Assets\Scripts\TableEntity/Table ^
    -x outputDataDir=%WORKSPACE%\..\Assets\Config\GenerateDatas\bytes ^
    -x pathValidator.rootDir=%WORKSPACE%\.. 

pause