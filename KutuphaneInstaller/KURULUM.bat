@echo off
chcp 65001 >nul
title Kütüphane Yönetim Sistemi - Kurulum

echo ===============================================
echo     KÜTÜPHANE YÖNETİM SİSTEMİ KURULUM
echo ===============================================
echo.

echo 📦 Kurulum başlatılıyor...
echo.

REM Kurulum dizinini oluştur
set "INSTALL_DIR=%ProgramFiles%\KutuphaneYonetimSistemi"
echo 📁 Kurulum dizini: %INSTALL_DIR%

if not exist "%INSTALL_DIR%" (
    echo 📁 Kurulum dizini oluşturuluyor...
    mkdir "%INSTALL_DIR%" 2>nul
    if errorlevel 1 (
        echo ❌ HATA: Kurulum dizini oluşturulamadı!
        echo 💡 Bu scripti yönetici olarak çalıştırın.
        pause
        exit /b 1
    )
)

echo 📋 Dosyalar kopyalanıyor...
copy "SimpleWindowsForm.exe" "%INSTALL_DIR%\" >nul
copy "SimpleWindowsForm.pdb" "%INSTALL_DIR%\" >nul
copy "e_sqlite3.dll" "%INSTALL_DIR%\" >nul
copy "README.txt" "%INSTALL_DIR%\" >nul

if errorlevel 1 (
    echo ❌ HATA: Dosyalar kopyalanamadı!
    pause
    exit /b 1
)

echo 🔗 Masaüstü kısayolu oluşturuluyor...
set "DESKTOP=%USERPROFILE%\Desktop"
set "SHORTCUT=%DESKTOP%\Kütüphane Yönetim Sistemi.lnk"

REM PowerShell ile kısayol oluştur
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut('%SHORTCUT%'); $Shortcut.TargetPath = '%INSTALL_DIR%\SimpleWindowsForm.exe'; $Shortcut.WorkingDirectory = '%INSTALL_DIR%'; $Shortcut.Description = 'Kütüphane Yönetim Sistemi'; $Shortcut.Save()" 2>nul

echo 📋 Başlat menüsü kısayolu oluşturuluyor...
set "STARTMENU=%APPDATA%\Microsoft\Windows\Start Menu\Programs"
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut('%STARTMENU%\Kütüphane Yönetim Sistemi.lnk'); $Shortcut.TargetPath = '%INSTALL_DIR%\SimpleWindowsForm.exe'; $Shortcut.WorkingDirectory = '%INSTALL_DIR%'; $Shortcut.Description = 'Kütüphane Yönetim Sistemi'; $Shortcut.Save()" 2>nul

echo.
echo ✅ KURULUM TAMAMLANDI!
echo.
echo 📍 Kurulum Konumu: %INSTALL_DIR%
echo 🖥️  Masaüstü kısayolu oluşturuldu
echo 📋 Başlat menüsünde bulabilirsiniz
echo.
echo 👤 Varsayılan kullanıcılar:
echo    admin / 123456 (Yönetici)
echo    librarian / 123456 (Kütüphaneci)
echo    user / 123456 (Kullanıcı)
echo.
echo 🚀 Uygulamayı başlatmak için masaüstündeki kısayola çift tıklayın!
echo.

choice /C YN /M "Uygulamayı şimdi başlatmak istiyor musunuz"
if errorlevel 2 goto :end
if errorlevel 1 goto :start

:start
echo 🚀 Uygulama başlatılıyor...
start "" "%INSTALL_DIR%\SimpleWindowsForm.exe"
goto :end

:end
echo.
echo Kurulum tamamlandı. Bu pencereyi kapatabilirsiniz.
pause >nul 