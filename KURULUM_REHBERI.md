# 📚 Kütüphane Yönetim Sistemi - Kurulum Rehberi

## 🎯 Gereksinimler

### Sistem Gereksinimleri
- **İşletim Sistemi**: Windows 10/11
- **RAM**: Minimum 4GB
- **Disk Alanı**: 500MB boş alan

### Yazılım Gereksinimleri
- **.NET 9.0 SDK** (Otomatik yüklenecek)
- **Git** (Opsiyonel - proje indirmek için)

## 🚀 Kurulum Adımları

### Yöntem 1: Git ile İndirme (Önerilen)

1. **Git Kurulumu** (Eğer yoksa)
   - [Git'i buradan indirin](https://git-scm.com/download/win)
   - Varsayılan ayarlarla kurun

2. **Projeyi İndirin**
   ```bash
   git clone https://github.com/vjuenx/library-system.git
   cd library-system
   ```

### Yöntem 2: ZIP Dosyası ile İndirme

1. **GitHub'dan İndirin**
   - [Proje sayfasına gidin](https://github.com/vjuenx/library-system)
   - "Code" → "Download ZIP" tıklayın
   - ZIP dosyasını masaüstüne çıkarın

## ⚡ Çalıştırma

### Otomatik Kurulum ve Çalıştırma

1. **Proje klasörünü açın**
   - Windows Explorer ile proje klasörüne gidin
   - Adres çubuğuna `cmd` yazın ve Enter'a basın

2. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

### İlk Çalıştırma
- Uygulama ilk çalıştırıldığında:
  - ✅ .NET 9.0 otomatik indirilecek (internet gerekli)
  - ✅ SQLite veritabanı otomatik oluşturulacak
  - ✅ Varsayılan kullanıcılar ve test verileri eklenecek
  - ✅ Uygulama açılacak

## 👥 Varsayılan Kullanıcılar

| Kullanıcı Adı | Şifre  | Rol               | Yetkiler                    |
|---------------|--------|-------------------|-----------------------------|
| `admin`       | 123456 | Sistem Yöneticisi | Tüm işlemler               |
| `librarian`   | 123456 | Kütüphaneci       | Kitap ve ödünç işlemleri   |
| `user`        | 123456 | Normal Kullanıcı  | Sadece kitap görüntüleme   |

## 📁 Proje Yapısı

```
library-system/
├── 📄 SimpleWindowsForm.csproj    # Proje dosyası
├── 📄 Program.cs                  # Ana program
├── 📄 LoginForm.cs               # Giriş ekranı
├── 📄 MainMenuForm.cs            # Ana menü
├── 📄 Database.cs                # Veritabanı yönetimi
├── 📁 Models/                    # Veri modelleri
├── 📁 Data/                      # Entity Framework
└── 📄 simple_ef_database.db      # SQLite veritabanı (otomatik oluşur)
```

## 🔧 Sorun Giderme

### .NET 9.0 Kurulum Sorunu
```bash
# Manuel .NET kurulumu
winget install Microsoft.DotNet.SDK.9
```

### Veritabanı Sorunu
- `simple_ef_database.db` dosyasını silin
- Uygulamayı yeniden çalıştırın (otomatik oluşacak)

### Port/Bağlantı Sorunu
- Antivirüs yazılımını geçici olarak kapatın
- Windows Defender'da proje klasörünü istisna ekleyin

## 📞 Destek

**Geliştirici**: vjuenx  
**Email**: soylubatuhan13@gmail.com  
**GitHub**: https://github.com/vjuenx/library-system

## 🎉 Başarılı Kurulum Kontrolü

Uygulama başarıyla çalıştığında:
- ✅ Login ekranı açılır
- ✅ `admin/123456` ile giriş yapabilirsiniz
- ✅ Ana menüde tüm modüller görünür
- ✅ Test verileri yüklenmiş olur

---

**Not**: İlk çalıştırma internet bağlantısı gerektirir (.NET indirme için). Sonraki çalıştırmalar offline çalışır. 