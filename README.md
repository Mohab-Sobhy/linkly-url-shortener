# Advanced URL Shortening System

![Project Screenshot](path-to-your-screenshot.png)  

---

## 🚀 Introduction
The **Advanced URL Shortening System** is a web-based application that allows users to shorten long URLs with two modes of usage:

- **Guest Mode:** Basic link shortening without tracking.  
- **Registered User Mode:** Advanced features including link management, analytics, and customization.

---

## 🎯 Purpose
The system enables users to:
- Shorten URLs quickly and easily.
- Track and analyze traffic for their shortened links.
- Customize links with aliases, expiration dates, password protection, and QR codes.

---

## 📌 Scope
The system provides:
- URL shortening for both guests and registered users.
- Analytics such as:
  - Number of visitors  
  - Visitor country (GeoIP)  
  - Device type (Mobile/Desktop/Tablet)  
  - Browser and OS information  
- Features like:
  - Custom aliases  
  - Expiration dates  
  - Password-protected links  
  - QR code generation  

---

## 🛠️ Technologies
- **Backend:** ASP.NET Core (REST API)  
- **Database ORM:** Entity Framework Core  
- **Authentication & Authorization:** ASP.NET Core Identity & JWT  
- **Database:** PostgreSQL  
- **Frontend:** React  

---

## 📖 Definitions
- **URL:** Uniform Resource Locator  
- **SRS:** Software Requirements Specification  
- **API:** Application Programming Interface  
- **GeoIP:** Geolocation by IP Address  

---

## 📐 System Architecture
- **Frontend:** React-based web client.  
- **Backend:** ASP.NET Core REST API handling business logic.  
- **Database:** PostgreSQL storing users, URL mappings, and visit analytics.  

---

## ⚙️ Features
### 🔗 URL Shortening
- Guests can shorten URLs.  
- Registered users can shorten URLs and store them in their accounts.  
- Unique shortcode generation.  
- Custom aliases for registered users.  

### 📝 URL Management (Registered Users Only)
- Create, update, or delete URLs.  
- Set expiration dates.  
- Generate QR codes.  
- Protect links with passwords.  

### 📊 Analytics (Registered Users Only)
- Record visits for each URL.  
- Track:
  - IP address & country  
  - Device type  
  - Browser & OS  
- Display data in charts and tables.  

### 🔄 Redirection
- Redirect visitors from short URLs to the original ones.  
- Show an error page if a link is expired or invalid.  

---

## ✅ Non-Functional Requirements
- **Performance:** Redirection < 300ms under normal load.  
- **Security:** All communications over HTTPS.  
- **Scalability:** Handle 10,000+ requests per day.  
- **Maintainability:** Follow Clean Architecture principles.  

---

## 👥 User Roles
- **Guest:** Shorten URLs without tracking.  
- **Registered User:** Full feature access (management, analytics, customization).  
- **Administrator:** Manage users, monitor system health, and handle abuse reports.  

---

## 📸 Demo / Screenshots

---

## 🚧 Installation & Setup

---

## 📜 License
This project is licensed under the MIT License.  
