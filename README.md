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
- **Kategori sistemi** ile organize edilmiş kitap koleksiyonu
- Raf konumu takibi
- Kopya sayısı ve müsaitlik durumu
- Kitap açıklaması ve yayın yılı
- **Kategori bazlı filtreleme** ve arama

### 📋 Kategori Yönetimi
- **Kitap kategorilerini organize etme**
- Kategori ekleme, düzenleme, silme
- Kategori açıklamaları
- **Kategoriye bağlı kitap sayısı** takibi
- Aktif/pasif kategori durumu
- **Varsayılan kategoriler**: Klasik Edebiyat, Bilim Kurgu, Bilgisayar Bilimleri, Tarih, Felsefe, Çocuk Kitapları, Akademik

### 📖 Ödünç Alma Sistemi
- **Gelişmiş ödünç kayıt yönetimi**
- Öğrenci ve kitap seçimi
- Ödünç alma ve iade tarihleri
- Gecikme ücreti hesaplama
- **Aktif ödünç takibi**
- **Geciken ödünçler** raporlama

### 📅 Rezervasyon Sistemi
- **Kitap rezervasyon yönetimi**
- Rezervasyon oluşturma ve iptal etme
- **Otomatik süre dolumu** kontrolü
- Rezervasyon durumu takibi (Aktif, Tamamlandı, İptal, Süresi Dolmuş)
- **Rezervasyon istatistikleri**

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
- **İlişkisel tablo yapısı** (7 tablo)
- **Foreign Key ilişkileri** ve veri bütünlüğü

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
├── 📄 CategoryManagementForm.cs    # Kategori yönetim formu
├── 📄 BorrowManagementForm.cs      # Ödünç alma formu
├── 📄 BorrowRecordManagementForm.cs # Ödünç kayıt yönetimi
├── 📄 ReservationManagementForm.cs # Rezervasyon yönetimi
├── 📄 SettingsForm.cs              # Ayarlar formu
├── 📄 Database.cs                  # Veritabanı yönetimi
├── 📁 Models/                      # Veri modelleri
│   ├── 📄 User.cs                  # Kullanıcı modeli
│   ├── 📄 Student.cs               # Öğrenci modeli
│   ├── 📄 Employee.cs              # Görevli modeli
│   ├── 📄 Book.cs                  # Kitap modeli
│   ├── 📄 Category.cs              # Kategori modeli
│   ├── 📄 BorrowRecord.cs          # Ödünç kayıt modeli
│   └── 📄 Reservation.cs           # Rezervasyon modeli
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
- **📋 Kategori Yönetimi** (Admin/Kütüphaneci)
- **📋 Ödünç Kayıtları** / **📖 Ödünç Alma** (Role göre)
- **📅 Rezervasyonlar** (Admin/Kütüphaneci)
- **⚙️ Ayarlar**

### 📋 Kategori Yönetimi
1. Ana menüden "📋 Kategori Yönetimi" seçin
2. **Yeni Kategori Ekleme**:
   - Kategori adını girin
   - Açıklama ekleyin (opsiyonel)
   - "➕ Ekle" butonuna tıklayın
3. **Kategori Güncelleme**:
   - Listeden kategori seçin
   - Bilgileri düzenleyin
   - "✏️ Güncelle" butonuna tıklayın
4. **Kategori Silme**:
   - Listeden kategori seçin
   - "🗑️ Sil" butonuna tıklayın
   - Onay verin

### 📚 Kitap Yönetimi (Kategori ile)
1. Ana menüden "📚 Kitap Yönetimi" seçin
2. **Yeni Kitap Ekleme**:
   - Kitap bilgilerini girin
   - **Kategori seçin** (dropdown'dan)
   - "➕ Ekle" butonuna tıklayın
3. **Kitap Listesi**: Kategoriler ile birlikte görüntülenir
4. **Kategori Filtreleme**: Kitaplar kategori adı ile listelenir

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
| **Kategori Yönetimi** | ✅ | ✅ | ❌ |
| Ödünç Kayıt Yönetimi | ✅ | ✅ | ❌ |
| Rezervasyon Yönetimi | ✅ | ✅ | ❌ |
| Ödünç Alma (Kullanıcı) | ✅ | ✅ | ✅ |
| Ayarlar | ✅ | ✅ | ❌ |

## 🗄️ Veritabanı Şeması (7 Tablo)

### 1. Users (Kullanıcılar)
- `Id` (Primary Key)
- `Username` (Unique)
- `Password`
- `Role` (Admin/Librarian/User)
- `FullName`
- `IsActive`
- `CreatedDate`

### 2. Students (Öğrenciler)
- `Id` (Primary Key)
- `Name`
- `StudentNumber` (Unique)
- `Email`
- `CreatedDate`

### 3. Employees (Görevliler)
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

### 4. Categories (Kategoriler) 🆕
- `Id` (Primary Key)
- `Name` (Unique)
- `Description`
- `IsActive`
- `CreatedDate`

### 5. Books (Kitaplar)
- `Id` (Primary Key)
- `Title`
- `Author`
- `ISBN` (Unique)
- `Publisher`
- `PublicationYear`
- `CategoryId` (Foreign Key → Categories) 🆕
- `ShelfLocation`
- `TotalCopies`
- `AvailableCopies`
- `Description`
- `IsActive`
- `CreatedDate`
- `UpdatedDate`

### 6. BorrowRecords (Ödünç Kayıtları)
- `Id` (Primary Key)
- `StudentId` (Foreign Key → Students)
- `BookId` (Foreign Key → Books)
- `BorrowDate`
- `DueDate`
- `ReturnDate`
- `IsReturned`
- `LateFee`
- `CreatedBy` (Foreign Key → Users)
- `CreatedDate`

### 7. Reservations (Rezervasyonlar)
- `Id` (Primary Key)
- `StudentId` (Foreign Key → Students)
- `BookId` (Foreign Key → Books)
- `ReservationDate`
- `ExpiryDate`
- `IsActive`
- `IsFulfilled`
- `FulfilledDate`
- `CreatedBy` (Foreign Key → Users)
- `CreatedDate`
- `Notes`

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

## 📊 Varsayılan Test Verileri

### Kategoriler
- **Klasik Edebiyat**: Dünya edebiyatının klasik eserleri
- **Bilim Kurgu**: Bilim kurgu ve fantastik romanlar
- **Bilgisayar Bilimleri**: Programlama, algoritma ve teknoloji kitapları
- **Tarih**: Tarih ve biyografi kitapları
- **Felsefe**: Felsefe ve düşünce kitapları
- **Çocuk Kitapları**: Çocuklar için hikaye ve eğitici kitaplar
- **Akademik**: Üniversite ve akademik çalışma kitapları

### Örnek Kitaplar
- **Suç ve Ceza** (Klasik Edebiyat)
- **1984** (Bilim Kurgu)
- **Algoritma ve Programlama** (Bilgisayar Bilimleri)

## 📝 Sürüm Geçmişi

- **v2.0.0** - Kategori Sistemi Güncellemesi 🆕
  - **Kategori yönetimi** eklendi
  - **Book-Category ilişkisi** kuruldu
  - **Ödünç kayıt sistemi** geliştirildi
  - **Rezervasyon sistemi** eklendi
  - **7 tablo** ile tam veritabanı yapısı
  - **Gelişmiş kullanıcı yetkilendirmesi**

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

**🎉 Kütüphane Yönetim Sistemi v2.0 - Modern, Güvenli, Kategori Destekli!** 