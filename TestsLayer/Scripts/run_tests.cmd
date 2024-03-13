@echo off 

REM Este script ejecuta las pruebas del proyecto 'TestsLayer' y crea el archivo de resultados en 
REM TestsLayer\Results\*.trx

vstest.console.exe %cd%\TestsLayer\bin\Debug\TestsLayer.dll --logger:trx --resultsdirectory:"%cd%\TestsLayer\Results"