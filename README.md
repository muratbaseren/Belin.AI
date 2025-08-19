# 🧠 BelinAI - Yapay Zeka ile Kod Yaz, Önizle, Yayınla!

BelinAI, yapay zeka destekli bir kod üretim platformudur. Kullanıcılar hiç programlama bilgisi olmadan, doğal dil ile konuşarak HTML, CSS ve JavaScript uygulamaları oluşturabilir.

## 🚀 Özellikler

### 💡 Ana Özellikler
- **Doğal Dil İle Kodlama**: Yapay zekaya sadece ne yapmak istediğinizi söyleyin, kodu o yazsın
- **Anında Önizleme**: Oluşturulan kodları gerçek zamanlı olarak test edin
- **Yayınlama Sistemi**: Kodlarınızı anında web'de yayınlayın ve paylaşın
- **Kullanıcı Bazlı Proje Yönetimi**: Tüm projelerinizi tek hesapta toplayın

### 🎯 Kullanım Modelleri
- **Ücretsiz Başlangıç**: Her yeni kullanıcı 10 ücretsiz AI kullanım hakkı ile başlar
- **Limitsiz Kullanım**: Kendi Google Gemini AI API anahtarınızla sınırsız kod üretimi
- **Admin Yönetimi**: Kullanıcı hakları ve AI kullanım limitleri için admin paneli

### 🛠️ Desteklenen Teknolojiler
- **Frontend**: HTML5, CSS3, JavaScript (ES6+)
- **Çıktı Formatı**: Tam fonksiyonel web uygulamaları
- **Proje Türleri**: Oyunlar, hesap makineleri, interaktif sayfalar, animasyonlar

## 🏗️ Teknik Mimari

### Backend (.NET 9 Blazor Server)
```
📁 BelinAI/
├── 📁 Components/
│   ├── 📁 Account/          # Kimlik doğrulama sayfaları
│   ├── 📁 Layout/           # Ana layout bileşenleri
│   ├── 📁 Pages/            # Uygulama sayfaları
│   └── 📁 Shared/           # Paylaşılan bileşenler
├── 📁 Data/                 # Veri modelleri ve DbContext
├── 📁 Services/             # İş mantığı servisleri
└── 📁 Migrations/           # Entity Framework migrations
```

### Veri Modeli
```csharp
// Kullanıcı modeli
ApplicationUser {
    Id, UserName, Email          // Identity temel alanları
    YzApiUrl, YzApiKey          // Kullanıcı API ayarları
    AIUseCount                  // Kalan AI kullanım hakkı
    UseAppAI                    // Limitsiz AI kullanım izni
    UserApps                    // Kullanıcının projeleri
}

// Proje modeli
UserApp {
    Id, Name, Code             // Proje bilgileri
    CreatedAt                  // Oluşturma tarihi
    AppUserId                  // Proje sahibi
}

// Sistem ayarları
Option {
    OptId                      // Ayar anahtarı
    ApiKey, Endpoint           // Global API ayarları
    PrePrompt                  // Varsayılan prompt
}
```

## 📦 Kurulum ve Çalıştırma

### Gereksinimler
- .NET 9 SDK
- SQLite (varsayılan) veya SQL Server
- Google Gemini AI API anahtarı (opsiyonel)

### Kurulum Adımları

1. **Projeyi klonlayın**
```bash
git clone https://github.com/kullanici-adi/BelinAI.git
cd BelinAI
```

2. **Bağımlılıkları yükleyin**
```bash
dotnet restore
```

3. **Veritabanını oluşturun**
```bash
dotnet ef database update
```

4. **Uygulamayı çalıştırın**
```bash
dotnet run
```

5. **Tarayıcıda açın**
```
https://localhost:5174
```

### İlk Admin Kullanıcısı
Kayıt olurken `xxx@gmail.com` email adresi ile kayıt olan kullanıcı otomatik olarak admin rolü alır.

## 🔧 Yapılandırma

### Google Gemini AI API Entegrasyonu
1. [Google AI Studio](https://aistudio.google.com/app/apikey) üzerinden API anahtarı alın
2. Admin panelinden (`/options`) global API ayarlarını yapın
3. Kullanıcılar kendi API anahtarlarını `Account/Manage/AIOptions` üzerinden tanımlayabilir

### Veritabanı Yapılandırması
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=BelinAI.db"
  }
}
```

## 🎮 Kullanım Örnekleri

### Örnek Prompt'lar
```
"Bana bir hafıza oyunu yap"
"Hesap makinesi oluştur"
"Animasyonlu bir landing page tasarla"
"Tic-tac-toe oyunu kodu yaz"
"Responsive bir portföy sitesi yap"
```

### Çıktı Örneği
```html
<!DOCTYPE html>
<html>
<head>
    <title>Hafıza Oyunu</title>
    <style>
        /* Oyun stilleri */
    </style>
</head>
<body>
    <div id="game">
        <!-- Oyun alanı -->
    </div>
    <script>
        // Oyun mantığı
    </script>
</body>
</html>
```

## 🔐 Güvenlik

### Kimlik Doğrulama
- ASP.NET Core Identity ile kullanıcı yönetimi
- Güvenli şifre gereksinimleri
- Oturum yönetimi

### API Güvenliği
- Kullanıcı API anahtarları şifreli saklanır
- Her kullanıcı sadece kendi projelerine erişebilir
- Admin paneli rol tabanlı korumalı

### Veri Koruması
- HTTPS zorunlu
- XSS ve CSRF koruması
- Güvenli cookie ayarları

## 🚀 Dağıtım

### Azure App Service
```bash
# Yayın profilini oluştur
dotnet publish -c Release

# Azure CLI ile dağıt
az webapp deploy --resource-group myResourceGroup --name myApp --src-path ./bin/Release/net9.0/publish.zip
```

### Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY publish/ .
EXPOSE 80
ENTRYPOINT ["dotnet", "BelinAI.dll"]
```

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Commit edin (`git commit -m 'Add amazing feature'`)
4. Push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

## 📞 İletişim

- **Geliştirici**: Murat Başeren
- **Website**: [about.me/KadirMuratBaseren](https://about.me/KadirMuratBaseren)
- **Demo**: [BelinAI Demo](your-demo-url)

## 🎯 Roadmap

### v1.1 İyileştirmeler
- [ ] Kod iyileştirme
- [ ] UI/UX iyileştirmeleri
- [ ] Kullanıcı bildirimleri
- [ ] Uygulama etkileşimi (beğeni, yorum sistemi)
- [ ] Uygulama klonlama ve paylaşma özellikleri

### v2.0 Planları
- [ ] Kod versiyon takibi
- [ ] Çoklu dil desteği
- [ ] Proje şablonları
---

⭐ **BelinAI ile kodlama herkesin hakkı!** Projeyi beğendiyseniz yıldız vermeyi unutmayın!