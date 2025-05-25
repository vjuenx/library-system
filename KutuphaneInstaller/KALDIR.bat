@echo off
chcp 65001 >nul
title Kütüphane Yönetim Sistemi - Kaldırma

echo ===============================================
echo   KÜTÜPHANE YÖNETİM SİSTEMİ KALDIRMA
echo ===============================================
echo.

echo ⚠️  Bu işlem uygulamayı tamamen kaldıracaktır!
echo.
choice /C YN /M "Devam etmek istediğinizden emin misiniz"
if errorlevel 2 goto :cancel
if errorlevel 1 goto :uninstall

:uninstall
echo.
echo 🗑️  Kaldırma işlemi başlatılıyor...

set "INSTALL_DIR=%ProgramFiles%\KutuphaneYonetimSistemi"
set "DESKTOP=%USERPROFILE%\Desktop"
set "STARTMENU=%APPDATA%\Microsoft\Windows\Start Menu\Programs"

echo 📁 Kurulum dizini siliniyor...
if exist "%INSTALL_DIR%" (
    rmdir /s /q "%INSTALL_DIR%" 2>nul
    if exist "%INSTALL_DIR%" (
        echo ❌ HATA: Kurulum dizini silinemedi!
        echo 💡 Bu scripti yönetici olarak çalıştırın.
        pause
        exit /b 1
    )
)

echo 🔗 Masaüstü kısayolu siliniyor...
if exist "%DESKTOP%\Kütüphane Yönetim Sistemi.lnk" (
    del "%DESKTOP%\Kütüphane Yönetim Sistemi.lnk" 2>nul
)

echo 📋 Başlat menüsü kısayolu siliniyor...
if exist "%STARTMENU%\Kütüphane Yönetim Sistemi.lnk" (
    del "%STARTMENU%\Kütüphane Yönetim Sistemi.lnk" 2>nul
)

echo.
echo ✅ KALDIRMA TAMAMLANDI!
echo.
echo 📁 Tüm dosyalar silindi
echo 🔗 Kısayollar kaldırıldı
echo.
echo Teşekkürler!
goto :end

:cancel
echo.
echo ❌ Kaldırma işlemi iptal edildi.

:end
echo.
pause 