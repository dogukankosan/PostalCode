# 📦 PostalCode

![License](https://img.shields.io/github/license/dogukankosan/PostalCode)
![Stars](https://img.shields.io/github/stars/dogukankosan/PostalCode)
![Issues](https://img.shields.io/github/issues/dogukankosan/PostalCode)
![Last Commit](https://img.shields.io/github/last-commit/dogukankosan/PostalCode)

> **PostalCode**, adres yönetimi için şehir ve ilçe bazlı posta kodu seçimini kolaylaştıran, SQL veritabanı ve Excel dosyası destekli bir masaüstü C#/.NET uygulamasıdır.

---

## 🚀 Özellikler

- 🗂 Şirket seçimi ile çoklu veritabanı desteği
- 📋 Cari kart ve adresler üzerinde toplu işlem
- 📊 Grid üzerinde adres ve posta kodu görüntüleme
- 🏙 Şehir/ilçe/mahalle bazında posta kodu seçimi (Excel dosyasından)
- ☑️ Seçilen posta kodunu tek tıkla kaydetme
- 🌐 PTT resmi posta kodu sayfası entegrasyonu (WebView)
- ⚡ Toplu güncelleme ve bilgi etiketleri
- 🛠 DevExpress arayüz bileşenleri ile modern görünüm

---

## 🗂 Proje Yapısı

```
PostalCode/
├── CompanyChoose.cs      # Şirket (veritabanı) seçimi arayüzü
├── Form1.cs             # Ana uygulama ekranı (adres, cari kart, posta kodu işlemleri)
├── PostaKodlari.cs      # Şehir/ilçe/mahalle seçimi ve posta kodu (Excel'den okuma)
├── database.txt         # SQL bağlantı bilgileri
├── excellocation.txt    # Excel dosyası yolu
└── ...                  # Diğer yardımcı dosya ve kaynaklar
```

---

## 🛠️ Kurulum & Çalıştırma

1. **Projeyi Klonla:**
   ```bash
   git clone https://github.com/dogukankosan/PostalCode.git
   cd PostalCode
   ```

2. **Bağlantıları Ayarla:**
   - `database.txt` dosyasına SQL bağlantı cümleni yaz.
   - `excellocation.txt` dosyasına Excel dosyasının yolunu ekle.

3. **Projeyi Visual Studio ile aç ve çalıştır (`F5`):**
   - İlk açılışta şirket (veritabanı) seçimi yap.
   - Ana ekranda cari kart ve adresler listelenir.
   - Grid'den bir satıra tıklayarak şehir ve ilçe seç, mahalle ve posta kodu listesini aç.
   - Mahalleyi seçip posta kodunu kaydet, ister tek tek, ister topluca veritabanına işle.

---

## ⚡ Kullanım Senaryosu

1. Uygulamayı başlat.
2. Şirket (veritabanı) seçimini yap.
3. Adresler/cari kartlar listelenir.
4. Satıra tıkla → mahalle ve posta kodları açılır → seçim yap → otomatik kaydedilir.
5. Toplu kayıt ve güncelleme işlemlerini kullanabilirsin.
6. PTT web sayfasını uygulama içinden görüntüleyebilirsin.

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.

---
