# 📚 Kütüphane Yönetim Sistemi

Modern ve kullanıcı dostu bir Windows Forms kütüphane yönetim uygulaması. Entity Framework Core ve SQLite veritabanı ile geliştirilmiştir.

## ✨ Özellikler

### 🔐 Güvenlik ve Kullanıcı Yönetimi
- **Giriş Sistemi**: Kullanıcı adı ve şifre ile güvenli giriş
- **Rol Tabanlı Yetkilendirme**: Admin, Kütüphaneci, Kullanıcı rolleri
- **Varsayılan Kullanıcılar**: 
  - `admin/123456` (Yönetici)
  - `librarian/123456` (Kütüphaneci)
  - `user/123456` (Kullanıcı)

### 👥 Görevli Yönetimi
- Personel ekleme, düzenleme, silme
- Departman ve pozisyon yönetimi
- Maaş ve işe başlama tarihi takibi
- Aktif/pasif durum kontrolü

### 🎓 Öğrenci Yönetimi
- Öğrenci kayıt sistemi (CRUD işlemleri)
- Öğrenci numarası, ad, email bilgileri
- Otomatik tarih damgalama
- Listele, güncelle, sil işlemleri

### 📚 Kitap Yönetimi
- Kitap katalog sistemi
- ISBN, yazar, yayınevi bilgileri
- Kategori ve raf konumu takibi
- Kopya sayısı ve müsaitlik durumu
- Kitap açıklaması ve yayın yılı

### 📖 Ödünç Alma Sistemi
- Kitap arama ve filtreleme
- Müsait kitapları görüntüleme
- Ödünç alma işlemleri
- Kitap durumu takibi

### ⚙️ Ayarlar ve Kişiselleştirme
- **Uygulama Hakkında**: Versiyon ve iletişim bilgileri
- **Tema Seçimi**: 
  - ☀️ Açık Tema (varsayılan)
  - 🌙 Koyu Tema
- **Anlık Tema Değişimi**: Temayı uygula butonu ile

## 🛠️ Teknik Özellikler

### Veritabanı
- **Entity Framework Core 9.0** ile SQLite entegrasyonu
- **Code First** yaklaşımı
- **Otomatik veritabanı oluşturma**
- **İlişkisel tablo yapısı**

### Güvenlik
- **Şifre korumalı giriş**
- **Rol tabanlı erişim kontrolü**
- **Oturum yönetimi**

### Kullanıcı Arayüzü
- **Modern Windows Forms tasarımı**
- **Renkli ve kategorize butonlar**
- **Responsive layout**
- **Tema desteği**
- **Türkçe arayüz**

## 📋 Gereksinimler

- **.NET 9.0 SDK** veya daha yeni sürüm
- **Windows** işletim sistemi
- **SQLite** (otomatik dahil)

## 🚀 Kurulum ve Çalıştırma

### 1. Projeyi İndirin
```bash
git clone https://github.com/vjuenx/library-system.git
cd library-system
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Uygulamayı Çalıştırın
```bash
dotnet run
```

### 4. Giriş Yapın
- **Kullanıcı Adı**: `admin`
- **Şifre**: `123456`

## 📁 Proje Yapısı

```
📦 library-system/
├── 📄 SimpleWindowsForm.csproj     # Proje dosyası
├── 📄 Program.cs                   # Uygulama giriş noktası
├── 📄 LoginForm.cs                 # Giriş formu
├── 📄 MainMenuForm.cs              # Ana menü formu
├── 📄 Form1.cs                     # Öğrenci yönetim formu
├── 📄 EmployeeManagementForm.cs    # Görevli yönetim formu
├── 📄 BookManagementForm.cs        # Kitap yönetim formu
├── 📄 BorrowManagementForm.cs      # Ödünç alma formu
├── 📄 SettingsForm.cs              # Ayarlar formu
├── 📄 Database.cs                  # Veritabanı yönetimi
├── 📁 Models/                      # Veri modelleri
│   ├── 📄 User.cs                  # Kullanıcı modeli
│   ├── 📄 Student.cs               # Öğrenci modeli
│   ├── 📄 Employee.cs              # Görevli modeli
│   └── 📄 Book.cs                  # Kitap modeli
├── 📁 Data/                        # Veritabanı context
│   └── 📄 AppDbContext.cs          # EF DbContext
├── 📄 simple_ef_database.db        # SQLite veritabanı
├── 📄 README.md                    # Bu dosya
└── 📄 .gitignore                   # Git ignore dosyası
```

## 🎯 Kullanım Kılavuzu

### 🔐 Giriş Yapma
1. Uygulama açıldığında giriş ekranı görünür
2. Kullanıcı adı ve şifre girin
3. "Giriş Yap" butonuna tıklayın

### 🏠 Ana Menü
Giriş yaptıktan sonra ana menüde şu seçenekler bulunur:
- **👥 Görevli Yönetimi** (Sadece Admin)
- **🎓 Öğrenci Yönetimi**
- **📚 Kitap Yönetimi**
- **📖 Ödünç Alma**
- **⚙️ Ayarlar**

### 🎨 Tema Değiştirme
1. Ana menüden "⚙️ Ayarlar" seçin
2. "🎨 Tema Ayarları" bölümünden istediğiniz temayı seçin
3. "✅ Temayı Uygula" butonuna tıklayın

## 👥 Kullanıcı Rolleri ve Yetkiler

| Özellik | Admin | Kütüphaneci | Kullanıcı |
|---------|-------|-------------|-----------|
| Görevli Yönetimi | ✅ | ❌ | ❌ |
| Öğrenci Yönetimi | ✅ | ✅ | ❌ |
| Kitap Yönetimi | ✅ | ✅ | ❌ |
| Ödünç Alma | ✅ | ✅ | ✅ |
| Ayarlar | ✅ | ✅ | ❌ |

## 🗄️ Veritabanı Şeması

### Users (Kullanıcılar)
- `Id` (Primary Key)
- `Username` (Unique)
- `Password`
- `Role` (Admin/Librarian/User)
- `FullName`
- `IsActive`
- `CreatedDate`

### Students (Öğrenciler)
- `Id` (Primary Key)
- `Name`
- `StudentNumber` (Unique)
- `Email`
- `CreatedDate`

### Employees (Görevliler)
- `Id` (Primary Key)
- `FullName`
- `EmployeeNumber` (Unique)
- `Email`
- `Phone`
- `Department`
- `Position`
- `Salary`
- `HireDate`
- `IsActive`
- `CreatedDate`

### Books (Kitaplar)
- `Id` (Primary Key)
- `Title`
- `Author`
- `ISBN` (Unique)
- `Publisher`
- `PublicationYear`
- `Category`
- `ShelfLocation`
- `TotalCopies`
- `AvailableCopies`
- `Description`
- `IsActive`
- `CreatedDate`

## 🔧 Geliştirme

### Yeni Özellik Ekleme
1. Uygun model sınıfını `Models/` klasörüne ekleyin
2. `AppDbContext.cs`'e DbSet ekleyin
3. Yeni form oluşturun
4. Ana menüden bağlantı yapın

### Veritabanı Değişiklikleri
- Code First yaklaşımı kullanılır
- `Database.cs`'de `EnsureCreated()` ile otomatik oluşturma
- Test verileri otomatik eklenir

## 📝 Sürüm Geçmişi

- **v1.0.0** - İlk sürüm
  - Temel CRUD işlemleri
  - Login sistemi
  - Rol tabanlı yetkilendirme
  - Tema desteği
  - Çoklu form yönetimi

## 🤝 Katkıda Bulunma

1. Projeyi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request oluşturun

## 📞 İletişim

- **Email**: library@example.com
- **GitHub**: [vjuenx/library-system](https://github.com/vjuenx/library-system)

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

---

**🎉 Kütüphane Yönetim Sistemi - Modern, Güvenli, Kullanıcı Dostu!** 