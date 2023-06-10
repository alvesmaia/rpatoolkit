@echo off

REM Ler a versão atual do arquivo
set /p version=<Version.txt
echo version

REM Separar as partes da versão
for /F "tokens=1,2,3 delims=." %%a in ("%version%") do (
    set "major=%%a"
    set "minor=%%b"
    set "patch=%%c"
)

REM Incrementar a parte desejada (no exemplo, o patch)
set /A patch+=1

REM Salvar a nova versão no arquivo
echo %major%.%minor%.%patch% > Version.txt
