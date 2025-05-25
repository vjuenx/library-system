@echo off
echo ================================
echo   Entity Framework Projesi
echo ================================
echo.
echo Proje baslatiliyor...
echo.

REM Paketleri geri yukle
echo [1/3] Paketler geri yukleniyor...
dotnet restore
if %errorlevel% neq 0 (
    echo HATA: Paketler geri yuklenemedi!
    pause
    exit /b 1
)

REM Projeyi derle
echo [2/3] Proje derleniyor...
dotnet build
if %errorlevel% neq 0 (
    echo HATA: Proje derlenemedi!
    pause
    exit /b 1
)

REM Projeyi calistir
echo [3/3] Proje calistiriliyor...
echo.
echo Windows Forms uygulamasi aciliyor...
dotnet run

echo.
echo Proje kapatildi.
pause 