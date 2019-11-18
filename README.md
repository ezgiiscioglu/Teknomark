# TEKNOMARK E-TİCARET SİTESİ
Teknomark, bilgisayar, telefon, tablet vb. teknolojik ürünlerin satıldığı bir e-ticaret sitesidir. ASP .NET MVC5 ile proje oluşturuldu. Authentication ve Authorization özellikleri kullanıldı. Çok dil özelliği kullanılmıştır.(İngilizce) Microsoft SQL Server Management Studio ile veritabanı yapıldı.

Projenin çalışma prensibi şu şekildedir:
- Kullanıcılar kayıt olabilir, giriş yapabilirler.
- Kayıt ol ve giriş yapma aşamalarında gerekli kontroller yapılmıştır. Girişi başarılı bir şekilde sağlayan kullanıcılar ana sayfaya yönlendirilir.
- Kullanıcılar seçtikleri kategorilerdeki ürünleri satın alabilirler.
- Üye olmayan kullanıcılar ürünleri görebilirler fakat satın alma işlemini
gerçekleştiremezler. Satın almak için sisteme üye olup giriş yapmaları gerekmektedir.
- Satın alma işleminde kart bilgileri girildikten sonra kullanıcıları iyzico sayfasına yönlendirilir. Ödev amaçlı bir proje olduğundan dolayı gerekli ticari işlemlerin devamı yapılmamıştır.
- Sistemde aynı zamanda admin girişi bulunmaktadır. Veritabanında belirttiğimiz admin bilgileri ile giriş yapıldığında admin paneline yönlendirme sağlanır.

Admin panelinin çalışma prensibi şu şekildedir:
- Admin ürün, kişi ve kategori yönetimi yapmaktadır.
- Ürün yönetiminde, yeni ürün oluşturma, ürünleri düzenleme, ürün detayları görme ve silme işlemlerini gerçekleştirebilir.
- Kişi yönetiminde, yeni üye oluşturma, üyeleri düzenleme, üye detaylarını görme ve üye silme işlemlerini gerçekleştirebilir. Admin isterse kullanıcı olan bir üyeye admin yetkisi verebilir.
- Kategori yönetiminde, yeni kategori ekleyebilir, kategorileri düzenleyebilir, kategori detaylarını görüntüleyebilir ve silme işlemlerini gerçekleştirebilir.

[![indir.png](https://i.postimg.cc/655D2Rvf/indir.png)](https://postimg.cc/XXm2trxr)
