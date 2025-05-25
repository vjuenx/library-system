# 📦 Kütüphane Yönetim Sistemi - Installer Rehberi

## 🎯 Hocanız İçin Installer Nedir?

**Installer**, uygulamanızı başka bilgisayarlara kolayca kurmak için hazırlanmış bir **kurulum paketi**dir. Bu, gerçek yazılım projelerinde kullanılan profesyonel bir yaklaşımdır.

## 📋 Hazırlanan Installer Özellikleri

### ✅ **Otomatik Kurulum**
- Tek tıkla kurulum (`KURULUM.bat`)
- Program Files klasörüne otomatik kurulum
- Masaüstü ve Başlat menüsü kısayolları
- Hata kontrolü ve kullanıcı bildirimleri

### ✅ **Profesyonel Dosya Yapısı**
```
KutuphaneInstaller/
├── SimpleWindowsForm.exe     (Ana uygulama - 136 MB)
├── e_sqlite3.dll            (SQLite veritabanı)
├── SimpleWindowsForm.pdb    (Debug bilgileri)
├── KURULUM.bat              (Kurulum scripti)
├── KALDIR.bat               (Kaldırma scripti)
└── README.txt               (Kullanım kılavuzu)
```

### ✅ **Self-Contained Uygulama**
- .NET Runtime dahil (başka bilgisayarda .NET yüklü olmasına gerek yok)
- Tüm bağımlılıklar tek dosyada
- Taşınabilir ve bağımsız çalışma

## 🚀 Hocanızın Kullanım Adımları

### **1. Installer'ı İndirme**
```bash
# GitHub'dan projeyi indirin
git clone https://github.com/vjuenx/library-system.git
cd library-system

# Veya direkt publish komutu ile oluşturun
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### **2. Kurulum**
1. `KutuphaneInstaller` klasörüne gidin
2. `KURULUM.bat` dosyasını **yönetici olarak** çalıştırın
3. Kurulum otomatik olarak tamamlanır
4. Masaüstünde kısayol oluşur

### **3. Kullanım**
- Masaüstündeki "Kütüphane Yönetim Sistemi" kısayoluna çift tıklayın
- Varsayılan kullanıcılarla giriş yapın:
  - `admin / 123456` (Yönetici)
  - `librarian / 123456` (Kütüphaneci)
  - `user / 123456` (Kullanıcı)

### **4. Kaldırma**
- `KALDIR.bat` dosyasını çalıştırın
- Tüm dosyalar ve kısayollar otomatik silinir

## 📊 Installer Avantajları

| Özellik | Açıklama |
|---------|----------|
| **Kolay Kurulum** | Tek tıkla kurulum, teknik bilgi gerektirmez |
| **Profesyonel Görünüm** | Gerçek yazılım gibi kurulum deneyimi |
| **Otomatik Kısayollar** | Masaüstü ve başlat menüsü entegrasyonu |
| **Temiz Kaldırma** | Tüm dosyaların temiz şekilde silinmesi |
| **Hata Yönetimi** | Kurulum hatalarında kullanıcı bilgilendirmesi |
| **Taşınabilirlik** | USB'de taşınabilir, internet gerektirmez |

## 🎓 Akademik Değer

Bu installer yaklaşımı şunları gösterir:

1. **Yazılım Dağıtımı Bilgisi**: Gerçek projelerde nasıl dağıtım yapıldığı
2. **Kullanıcı Deneyimi**: Son kullanıcı için kolay kurulum
3. **Sistem Entegrasyonu**: Windows ile entegrasyon (kısayollar, menüler)
4. **Profesyonel Yaklaşım**: Endüstri standartlarına uygun paketleme
5. **Deployment Stratejisi**: .NET uygulamalarının dağıtım yöntemleri

## 💡 Hocanıza Sunabileceğiniz Seçenekler

### **Seçenek 1: Hazır Installer** (Önerilen)
- `KutuphaneInstaller` klasöründeki dosyaları kullanın
- `KURULUM.bat` ile tek tıkla kurulum

### **Seçenek 2: Portable Versiyon**
- Sadece `SimpleWindowsForm.exe` dosyasını çalıştırın
- Kurulum gerektirmez, direkt çalışır

### **Seçenek 3: Kaynak Koddan Çalıştırma**
```bash
git clone https://github.com/vjuenx/library-system.git
cd library-system
dotnet run
```

## 📝 Teslim Önerisi

Hocanıza şu şekilde teslim edebilirsiniz:

1. **GitHub Repository**: Kaynak kod + installer scriptleri
2. **USB/CD**: `KutuphaneInstaller` klasörü
3. **Email**: Installer scriptleri + kullanım kılavuzu
4. **Demo**: Canlı kurulum gösterimi

Bu yaklaşım, projenizin sadece bir ödev değil, gerçek bir yazılım projesi olduğunu gösterir! 🚀 