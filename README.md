# Entity Framework Windows Form Projesi

Bu çok basit bir Windows Forms uygulamasıdır. Entity Framework Core ile SQLite veritabanı kullanır.

## Özellikler

- Entity Framework Core entegrasyonu
- SQLite veritabanı
- Otomatik veritabanı oluşturma (Code First)
- Student (Öğrenci) modeli
- Veritabanı durumu göstergesi
- Test verisi otomatik ekleme

## Gereksinimler

- .NET 9.0 SDK veya daha yeni sürüm
- Windows işletim sistemi

## Nasıl Çalıştırılır

1. Proje klasöründe terminal/komut satırını açın
2. Paketleri geri yükleyin:

```bash
dotnet restore
```

3. Uygulamayı çalıştırın:

```bash
dotnet run
```

## Dosya Yapısı

- `SimpleWindowsForm.csproj` - Proje dosyası (EF Core paketleri dahil)
- `Program.cs` - Uygulamanın giriş noktası
- `Form1.cs` - Ana form sınıfı (EF durumu gösterimi)
- `Database.cs` - Veritabanı yönetim sınıfı (EF entegrasyonu)
- `Models/Student.cs` - Öğrenci entity modeli
- `Data/AppDbContext.cs` - Entity Framework DbContext
- `README.md` - Bu dosya
- `simple_ef_database.db` - SQLite veritabanı dosyası (otomatik oluşturulur)

## Entity Framework Yapısı

### Models
- **Student**: Öğrenci bilgileri (Id, Name, StudentNumber, Email, CreatedDate)

### Database
- **Tip**: SQLite
- **Konum**: Proje klasöründe `simple_ef_database.db`
- **Yaklaşım**: Code First (migration olmadan)
- **Otomatik oluşturma**: Evet

### Özellikler
- Unique constraint: StudentNumber
- Otomatik test verisi ekleme
- Entity Framework Core 9.0

## Kullanım

Uygulama çalıştığında:
1. Entity Framework otomatik olarak veritabanını oluşturur
2. Test öğrenci verisi eklenir (eğer tablo boşsa)
3. EF durumu ve öğrenci sayısı ekranda gösterilir
4. "EF Durumunu Kontrol Et" butonuna tıklayarak detayları görebilirsiniz

## Taşınabilirlik

Bu proje başka bilgisayarlarda çalıştırılabilir:
- Entity Framework Code First kullanır
- Veritabanı otomatik oluşturulur
- Hiçbir manuel konfigürasyon gerekmez 