# Müşteri Yönetim Sistemi

## Genel Bakış

Müşteri Yönetim Sistemi, ASP.NET Core WebAPI kullanılarak geliştirilmiş bir örnek projedir. JWT kimlik doğrulama özelliğine sahiptir ve müşteri verilerini yönetmek için yaygın işlemleri gösterir.

## Özellikler

- **Kimlik Doğrulama**: JWT token kullanarak güvenli giriş.
- **Müşteri Yönetimi**: Müşteri verilerini yönetmek için CRUD işlemleri.
- **Rol Yönetimi**: Kullanıcılar için rol atama ve yönetme.
- **Middleware**: Tutarlı hata yanıtları için özel hata yönetim katmanı.

## Başlarken

### Gereksinimler

- .NET 6 SDK
- SQL Server

### Kurulum

1. Depoyu klonlayın:
    ```sh
    git clone https://github.com/bozomemo/CustomerManegementSystem.git
    ```
2. Proje dizinine gidin:
    ```sh
    cd CustomerManegementSystem
    ```
3. Bağımlılıkları geri yükleyin:
    ```sh
    dotnet restore
    ```

### Veritabanı Kurulumu

1. `appsettings.json` dosyasındaki bağlantı dizesini SQL Server örneğinize göre güncelleyin.
2. Veritabanı şemasını oluşturmak için migrasyonları uygulayın:
    ```sh
    dotnet ef database update
    ```
3. Veritabanı yedeğini (`CMS_Database.bak`) SQL Server Management Studio (SSMS) kullanarak geri yükleyin.

### Uygulamayı Çalıştırma

1. Projeyi derleyin:
    ```sh
    dotnet build
    ```
2. Projeyi çalıştırın:
    ```sh
    dotnet run
    ```

### API Dokümantasyonu

Swagger aracılığıyla API dokümantasyonu mevcuttur. Uygulama çalıştığında, kullanılabilir uç noktaları keşfetmek için tarayıcınızda `/swagger` adresine gidin.

## Kullanım

### Kimlik Doğrulama

- Geçerli kullanıcı kimlik bilgileriyle `/api/auth/login` adresine POST isteği göndererek JWT token alın.
- Sonraki istekler için `Authorization` başlığında token kullanın.

### Müşteri İşlemleri

- **Tüm Müşterileri Getir**: `GET /api/customers`
- **ID ile Müşteri Getir**: `GET /api/customers/{id}`
- **Müşteri Oluştur**: `POST /api/customers`
- **Müşteri Güncelle**: `PUT /api/customers`
- **Müşteri Sil**: `DELETE /api/customers/{id}`

## Katkıda Bulunma

Katkılar memnuniyetle karşılanır! Herhangi bir iyileştirme veya hata için bir pull request gönderin veya bir issue açın.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır.

---

Daha fazla detay için [repo](https://github.com/bozomemo/CustomerManegementSystem) adresini ziyaret edin.
