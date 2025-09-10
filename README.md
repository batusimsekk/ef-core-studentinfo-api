# 🎓 Öğrenci Bilgi Sistemi – ASP.NET Core Web API & HTML Forms

Bu proje, **ASP.NET Core Web API** ve **Entity Framework Core** kullanılarak geliştirilmiş bir **Öğrenci Bilgi Sistemi** uygulamasıdır.  
Öğrenci bilgileri SQL Server üzerinde tutulur, CRUD işlemleri hem **Swagger/Postman** üzerinden hem de **HTML + JavaScript formlar** ile yapılabilir.  

---

## 🚀 Kullanılan Teknolojiler
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core (EF Core)
- Microsoft SQL Server
- Bogus (Fake data için)
- HTML5, CSS3, JavaScript
- Bootstrap 5

---

## 📂 Proje Yapısı

- **StudentInfoAPI**: Veritabanı ve API katmanı (Controllers, Entities, DbContext).
- **student-forms**: Öğrencileri listeleme, ekleme, güncelleme ve silme işlemleri için arayüz.

---

## 🗄️ Veritabanı
- **Entity:** `StudentEntity`  
  - `Id` (int, otomatik artan – Primary Key)  
  - `FirstName` (zorunlu)  
  - `LastName` (zorunlu)  
  - `Number` (zorunlu, benzersiz)  
  - `Class` (opsiyonel)  

Uygulama ilk çalıştırıldığında, **Bogus kütüphanesi** ile tabloya otomatik olarak **20 sahte öğrenci** eklenir.

---



