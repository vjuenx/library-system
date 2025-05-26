@echo off
echo ========================================
echo   KUTUPAHNE YONETIM SISTEMI KURULUM
echo ========================================
echo.

echo [1/4] .NET SDK kontrol ediliyor...
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ .NET SDK bulunamadi!
    echo 📥 .NET 9.0 indiriliyor...
    winget install Microsoft.DotNet.SDK.9
    if %errorlevel% neq 0 (
        echo ❌ .NET kurulumu basarisiz!
        echo 🌐 Manuel kurulum: https://dotnet.microsoft.com/download
        pause
        exit /b 1
    )
) else (
    echo ✅ .NET SDK mevcut
)

echo.
echo [2/4] Proje paketleri geri yukleniyor...
dotnet restore
if %errorlevel% neq 0 (
    echo ❌ Paket geri yukleme basarisiz!
    pause
    exit /b 1
)
echo ✅ Paketler geri yuklendi

echo.
echo [3/4] Proje derleniyor...
dotnet build
if %errorlevel% neq 0 (
    echo ❌ Derleme basarisiz!
    pause
    exit /b 1
)
echo ✅ Proje derlendi

echo.
echo [4/4] Uygulama baslatiliyor...
echo.
echo ========================================
echo   KURULUM TAMAMLANDI!
echo ========================================
echo.
echo 👥 Varsayilan kullanicilar:
echo    admin / 123456 (Yonetici)
echo    librarian / 123456 (Kutuphaneci)
echo    user / 123456 (Kullanici)
echo.
echo 🚀 Uygulama aciliyor...
echo.

dotnet run 