# 🚀 TaskHive

TaskHive, ekiplerin ve kullanıcıların **takım, proje ve görev süreçlerini tek bir platform üzerinden yönetebilmesini** sağlayan, ASP.NET Core MVC ve .NET 8 kullanılarak geliştirilmiş bir web uygulamasıdır.

Proje; takım yönetimi, proje ve görev takibi, kullanıcı yönetimi, bildirimler, yorumlar ve takım içi mesajlaşma gibi temel iş süreçlerini tek bir uygulama içerisinde bir araya getirmeyi amaçlamaktadır.

TaskHive, gerçek bir ürün olarak konumlandırılmaktan ziyade **.NET backend ve web uygulaması geliştirme becerilerini geliştirmek, gerçek uygulamalarda karşılaşılabilecek senaryoları deneyimlemek ve sürdürülebilir bir proje mimarisi oluşturmak amacıyla geliştirilmiş bir portföy projesidir.**

---

## 📌 Proje Amacı

TaskHive'ın temel amacı, ekiplerin günlük çalışma süreçlerini daha düzenli bir şekilde yönetebileceği bir platformun nasıl geliştirilebileceğini deneyimlemektir.

Proje kapsamında;

* Kullanıcı ve rol yönetimi
* Takım oluşturma ve takım üyeliği
* Proje yönetimi
* Görev oluşturma ve görev atama
* Görev üyelerinin yönetimi
* Bildirim sistemi
* Görev yorumları
* Kullanıcı profil yönetimi
* Takım ve özel mesajlaşma
* Okunmamış mesaj takibi
* Rol bazlı yetkilendirme
* Soft delete yaklaşımı

gibi farklı uygulama senaryoları ele alınmıştır.

---

## 🛠 Kullanılan Teknolojiler

### Backend

* C#
* .NET 8
* ASP.NET Core MVC
* Entity Framework Core
* ASP.NET Core Identity
* SQL Server

### Frontend

* Razor Views
* HTML5
* CSS3
* JavaScript
* Bootstrap
* Bootstrap Icons

### Architecture & Development

* Layered Architecture
* Repository Pattern
* Manager / Business Layer yaklaşımı
* Dependency Injection
* ViewModel kullanımı
* Entity Framework Core Migrations
* Role-Based Authorization
* Git & GitHub

---

## 🏗 Mimari Yapı

TaskHive, sorumlulukların birbirinden ayrılmasını sağlamak amacıyla katmanlı mimari yaklaşımı kullanılarak geliştirilmiştir.

```text
TH.MVCUI
   │
   ▼
TH.BLL
   │
   ▼
TH.DAL
   │
   ▼
TH.CONF
   │
   ▼
TH.ENTITIES
```

### 📂 TH.ENTITIES

Uygulamanın domain modellerini ve enum yapılarını içerir.

Örnek modeller:

* User
* AppUser
* Team
* TeamMember
* Project
* Task
* TaskMember
* Notification
* TaskComment
* Conversation
* ConversationParticipant
* Message
* Role

### ⚙ TH.CONF

Entity Framework Core yapılandırmalarının ve DbContext altyapısının bulunduğu katmandır.

Bu katmanda;

* Entity configuration
* DbContext
* Database bağlantısı
* Entity ilişkileri
* Seed işlemleri

gibi veritabanı yapılandırmaları yönetilmektedir.

### 🗄 TH.DAL

Veritabanı erişim işlemlerinden sorumlu katmandır.

Repository yapısı kullanılarak veri erişim işlemleri Business Layer'dan ayrılmıştır.

### 🧠 TH.BLL

Uygulamanın iş mantığının bulunduğu katmandır.

Manager yapıları üzerinden;

* İş kuralları
* Validasyon kontrolleri
* Repository çağrıları
* Domain işlemleri

yönetilmektedir.

### 🖥 TH.MVCUI

Kullanıcı arayüzünün ve HTTP isteklerinin yönetildiği Presentation Layer'dır.

Bu katmanda;

* Controllers
* Razor Views
* ViewModels
* Areas
* ViewComponents
* Authentication / Authorization akışları

yer almaktadır.

---

## 🚀 Temel Özellikler

### 👤 Kullanıcı Yönetimi

* Kullanıcı kayıt ve giriş işlemleri
* ASP.NET Core Identity entegrasyonu
* Kullanıcı profili
* Profil bilgilerinin güncellenmesi
* Profil fotoğrafı desteği
* Kullanıcı ve rol yönetimi

### 👥 Takım Yönetimi

* Takım oluşturma
* Takım üyelerini yönetme
* Kullanıcıları takımlara dahil etme
* Takımdan kullanıcı çıkarma
* Takım bazlı erişim kontrolleri

### 📁 Proje Yönetimi

* Proje oluşturma
* Proje güncelleme
* Proje silme
* Projeleri takımlarla ilişkilendirme
* Proje kullanıcılarının yönetimi

### ✅ Görev Yönetimi

* Görev oluşturma
* Görev güncelleme
* Görev silme
* Görev atama
* Görev üyelerini yönetme
* Öncelik yönetimi
* Görev durumlarının takibi

### 💬 Yorum Sistemi

Kullanıcıların görevler üzerinden yorum yapabilmesini sağlayan yorum sistemi bulunmaktadır.

### 🔔 Bildirim Sistemi

Kullanıcılara uygulama içerisindeki ilgili işlemler hakkında bildirim gösterilebilmesi için bildirim altyapısı geliştirilmiştir.

### 💬 Mesajlaşma Sistemi

TaskHive içerisinde takım ve özel konuşmaları destekleyen bir mesajlaşma sistemi bulunmaktadır.

Mesajlaşma sistemi kapsamında;

* Takım sohbetleri
* Özel sohbetler
* Konuşma katılımcıları
* Okunmamış mesaj takibi
* Son okunan mesaj takibi
* Mesaj gönderme
* Konuşma geçmişi
* Takımdan çıkarılan kullanıcıların geçmiş mesajlarının korunması
* Kullanıcının erişim yetkisinin kaldırılması

gibi senaryolar ele alınmıştır.

### 🔐 Yetkilendirme

ASP.NET Core Identity ve role-based authorization kullanılarak kullanıcıların erişebileceği alanlar ayrılmıştır.

Mevcut yapı içerisinde;

* Admin
* Member

rolleri bulunmaktadır.

Bunun yanında takım içerisindeki kullanıcı ilişkileri ayrıca kontrol edilerek kullanıcının yalnızca dahil olduğu takım ve konuşmalara erişebilmesi sağlanmıştır.

---

## 🗃 Veritabanı

TaskHive, SQL Server üzerinde Entity Framework Core kullanılarak geliştirilmiştir.

Entity'ler arasındaki ilişkiler EF Core üzerinden tanımlanmış ve veritabanı değişiklikleri migrations aracılığıyla yönetilmiştir.

Önemli ilişkiler arasında;

```text
User
 ├── Teams
 ├── Projects
 ├── Tasks
 ├── Notifications
 └── Messages

Team
 ├── TeamMembers
 ├── Projects
 └── Conversation

Project
 └── Tasks

Conversation
 ├── Participants
 └── Messages
```

yer almaktadır.

---

## 🛡 Güvenlik ve Veri Yönetimi

Projede kullanıcı erişimlerini kontrol etmek için ASP.NET Core Identity ve authorization mekanizmaları kullanılmıştır.

Ayrıca uygulamada soft delete yaklaşımı kullanılarak bazı kayıtların fiziksel olarak veritabanından silinmesi yerine durum bilgilerinin değiştirilmesi tercih edilmiştir.

Bu yaklaşım özellikle mesajlaşma ve takım üyeliği gibi geçmiş verilerin korunmasının önemli olduğu senaryolarda kullanılmıştır.

---

## 🎨 Kullanıcı Arayüzü

TaskHive'ın arayüzü Bootstrap tabanlı dashboard yaklaşımı kullanılarak geliştirilmiştir.

Uygulamada Admin ve Member kullanıcıları için farklı alanlar ve navigasyon yapıları bulunmaktadır.

Temel arayüz bölümleri:

* Dashboard
* Takımlarım
* Projeler
* Görevler
* Bildirimler
* Yorumlar
* Mesajlar
* Profil

---

## 📸 Ekran Görüntüleri

> Projenin temel ekran görüntüleri aşağıda paylaşılacaktır.

### Admin Dashboard

<img width="1911" height="912" alt="Admin_Dashboard" src="https://github.com/user-attachments/assets/2a93f880-d048-4390-8c75-4766c6ec6b94" />

### Kullanıcı Dashboard

<img width="1595" height="911" alt="Member_Dashboard" src="https://github.com/user-attachments/assets/d606cee3-78ba-4089-a608-0c384bc67824" />

### Takımlar

<img width="1627" height="907" alt="Admin_Takımlar" src="https://github.com/user-attachments/assets/779c7812-3739-4680-a4b9-943068e45c14" />

### Projeler

<img width="1600" height="902" alt="Admin_Projects_1" src="https://github.com/user-attachments/assets/4685d2bc-ab0d-461d-83a3-33222e3e0630" />

<img width="1627" height="911" alt="Admin_Projects_2" src="https://github.com/user-attachments/assets/0cadd363-9e58-466f-945f-b5ea5b8a0903" />

### Görevler

<img width="1590" height="897" alt="Admin_Tasks_1" src="https://github.com/user-attachments/assets/44a3b118-2efd-4786-9798-45a75e56a588" />

<img width="1625" height="915" alt="Admin_Tasks_2" src="https://github.com/user-attachments/assets/418ff798-c83b-40f8-b505-c3ea2b107a1c" />

### Mesajlaşma

<img width="1592" height="910" alt="Messages" src="https://github.com/user-attachments/assets/8a9e1d90-6df5-4659-b3e7-35e4ad4fc813" />

### Bildirimler

<img width="1597" height="907" alt="Notifications" src="https://github.com/user-attachments/assets/0853a17c-2d7d-4a44-a0ac-0501db1a9299" />

---

## ⚙ Kurulum

### Gereksinimler

Projeyi çalıştırabilmek için aşağıdaki araçların sisteminizde bulunması gerekir:

* .NET 8 SDK
* SQL Server
* Visual Studio 2022 veya .NET destekleyen bir IDE

### Repository'yi Klonlama

```bash
git clone https://github.com/ozanerel/TaskHive.git
```

Repository klasörüne geçin:

```bash
cd TaskHive
```

### Veritabanı Bağlantısı

`TH.MVCUI/appsettings.json` içerisinde kendi SQL Server bağlantı bilginizi tanımlayın.

Örnek:

```json
{
  "ConnectionStrings": {
    "MyConnection": "Server=YOUR_SERVER;Database=TaskHiveDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> ⚠️ Güvenlik nedeniyle gerçek connection string bilgileri repository içerisinde paylaşılmamaktadır.

### Veritabanını Oluşturma

Package Manager Console veya .NET CLI üzerinden mevcut migrations kullanılarak veritabanı oluşturulabilir.

```bash
Update-Database
```

veya:

```bash
dotnet ef database update
```

### Uygulamayı Çalıştırma

Projeyi Visual Studio üzerinden çalıştırabilir veya:

```bash
dotnet run
```

komutunu kullanabilirsiniz.

### 👤 Demo Hesapları

Uygulamanın ilk testleri ve demo kullanımı için seed işlemleri sırasında örnek Admin ve Member hesapları oluşturulmaktadır.

| Rol    | Kullanıcı Adı | Şifre        |
| ------ | ------------- | ------------ |
| Admin  | `Admin`       | `Admin1234`  |
| Member | `Member`      | `Member1234` |

> ⚠️ Bu hesaplar uygulamanın demo ve test amacıyla kullanılabilmesi için seed data içerisinde oluşturulmuştur.

### 📝 Yeni Kullanıcı Kaydı

Uygulama içerisindeki kayıt ekranı üzerinden yeni bir Member hesabı oluşturulabilir.

Yeni kayıt olan kullanıcılar giriş yaparken:

* **Kullanıcı Adı:** Kayıt sırasında kullanılan e-posta adresi
* **Şifre:** Kayıt sırasında belirlenen şifre

bilgilerini kullanır.

Seed ile oluşturulan `Admin` ve `Member` hesapları ise demo/test amacıyla kullanılan başlangıç hesaplarıdır.

---

## 🎯 Proje ile Kazanılan Deneyimler

TaskHive geliştirme sürecinde özellikle aşağıdaki konularda pratik yapılmıştır:

* ASP.NET Core MVC
* .NET 8
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Layered Architecture
* Repository Pattern
* Dependency Injection
* Role-Based Authorization
* Entity ilişkilerinin tasarlanması
* ViewModel kullanımı
* Soft Delete yaklaşımı
* Authentication / Authorization
* Takım bazlı erişim kontrolü
* Mesajlaşma sistemlerinin tasarlanması
* Git & GitHub workflow
* Gerçek uygulamalarda karşılaşılabilecek edge-case senaryolarının çözülmesi

---

## 🔮 Gelecekte Eklenebilecek Özellikler

TaskHive'ın geliştirme süreci tamamlanmış olmakla birlikte proje, gelecekte farklı ihtiyaçlara göre genişletilebilecek şekilde tasarlanmıştır.

Olası geliştirmeler:

* Gerçek zamanlı mesajlaşma için SignalR
* Gelişmiş dashboard ve raporlama
* Dosya ekleme ve paylaşma
* E-posta bildirimleri
* RESTful API
* Mobil veya ayrı frontend uygulaması
* Daha gelişmiş arama ve filtreleme özellikleri


---

## 👨‍💻 Geliştirici

**Ozan Erel**

.NET Backend / Full Stack Developer


---

## 📄 Lisans

Bu proje eğitim, öğrenme ve portföy geliştirme amacıyla oluşturulmuştur.
