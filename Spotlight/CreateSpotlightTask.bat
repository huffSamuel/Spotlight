@echo off
set /p dir="Enter path to Spotlight.exe: "
schtasks /Create /tn Spotlight /sc WEEKLY /tr %dir%