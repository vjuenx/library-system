# Proje Kurulum Rehberi - Hoca Bilgisayarı

Bu rehber, projenin başka bir bilgisayarda nasıl çalıştırılacağını açıklar.

## Gereksinimler

### 1. .NET SDK Kurulumu
Hocanızın bilgisayarında .NET SDK kurulu olmalı.

**Kontrol etmek için:**
```bash
dotnet --version
```

**Eğer kurulu değilse:**
- [Microsoft .NET Download](https://dotnet.microsoft.com/download) adresinden .NET 8.0 veya 9.0 SDK'sını indirin
- Kurulum dosyasını çalıştırın
- Bilgisayarı yeniden başlatın

## Proje Kurulum Adımları

### Adım 1: Proje Dosyalarını Kopyalayın
Tüm proje klasörünü hocanızın bilgisayarına kopyalayın:
```
simple/
├── SimpleWindowsForm.csproj
├── Program.cs
├── Form1.cs
├── Database.cs
├── Models/
│   └── Student.cs
├── Data/
│   └── AppDbContext.cs
├── README.md
└── KURULUM_REHBERI.md
```

### Adım 2: Terminal/Komut Satırını Açın
- Windows: `cmd` veya `PowerShell`
- Proje klasörüne gidin: `cd C:\path\to\simple`

### Adım 3: Paketleri Geri Yükleyin
```bash
dotnet restore
```

### Adım 4: Projeyi Derleyin
```bash
dotnet build
```

### Adım 5: Projeyi Çalıştırın
```bash
dotnet run
```

## Otomatik Kurulum (Tek Komut)

Proje klasöründe aşağıdaki komutu çalıştırın:
```bash
dotnet restore && dotnet build && dotnet run
```

## Beklenen Sonuç

Uygulama çalıştığında:
1. ✅ Windows Forms penceresi açılır
2. ✅ "Entity Framework Projesi" başlığı görünür
3. ✅ "Veritabanı Bağlantısı: Başarılı" mesajı
4. ✅ "Entity Framework: Aktif (1 öğrenci)" mesajı
5. ✅ "EF Durumunu Kontrol Et" butonu çalışır

## Veritabanı

- **Otomatik oluşturulur**: `simple_ef_database.db`
- **Konum**: `bin\Debug\net9.0-windows\` klasöründe
- **Test verisi**: Otomatik olarak 1 öğrenci eklenir

## Sorun Giderme

### Problem: ".NET SDK bulunamadı"
**Çözüm**: .NET SDK'yı yükleyin ve PATH'e ekleyin

### Problem: "Paket geri yüklenemedi"
**Çözüm**: İnternet bağlantısını kontrol edin, tekrar deneyin:
```bash
dotnet restore --force
```

### Problem: "Veritabanı hatası"
**Çözüm**: Klasör yazma izinlerini kontrol edin

### Problem: "Form açılmıyor"
**Çözüm**: Windows'ta çalıştığınızdan emin olun

## Proje Özellikleri

- ✅ **Taşınabilir**: Hiçbir manuel konfigürasyon gerekmez
- ✅ **Otomatik**: Veritabanı kendisi oluşturulur
- ✅ **Basit**: Tek komutla çalışır
- ✅ **Entity Framework**: Code First yaklaşımı

## İletişim

Herhangi bir sorun yaşanırsa, proje sahibiyle iletişime geçin. 