# 📚 Library Management System

A **Library Management System** built with **ASP.NET MVC** following a clean layered architecture.
It provides CRUD operations for managing books, users, and transactions, with a modern UI powered by **Bootstrap, jQuery validation, SweetAlert, and Select2** for enhanced interactivity.

---

## 🚀 Features

* 📖 **Books Management** – Add, update, delete, and search books.
* 👤 **User Management** – Register and manage library users.
* 🔄 **Transactions** – Track borrowing and returning of books.
* 🏛️ **Repository + Service Layers** – Clean separation of concerns.
* 🎨 **UI Enhancements**:

  * Bootstrap for styling
  * jQuery validation for forms
  * SweetAlert for delete confirmations
  * Select2 for autocomplete search
  * 🖼️ **Live Preview of Book Covers** – Instantly preview uploaded cover images before saving
* 🖼️ **Custom Attributes**:

  * Validate allowed image extensions
  * Ensure file size < 1MB
* 🔄 **AutoMapper** for mapping DTOs ↔ Models

---

## 🛠️ Tech Stack

* **Backend:** ASP.NET MVC, C#
* **Frontend:** Bootstrap, jQuery, SweetAlert, Select2
* **Database:** Entity Framework Core (Code First + Migrations)
* **Architecture:** Repository Pattern, Service Layer, DTOs, AutoMapper

---

## 📂 Project Structure

```
├── Attributes          # Custom validation attributes
├── Consts              # Constants (File settings, OrderBy, Transaction types)
├── Controllers         # MVC controllers (Books, Users, Transactions, Home)
├── Data                # DbContext
├── DTOs                # Data Transfer Objects (Books, Users, Transactions)
├── Extentions          # Service extensions
├── Mapping             # AutoMapper profiles
├── Migrations          # EF Core migrations
├── Models              # Entity models (Book, User, Transaction)
├── Repositories        # Repository interfaces & implementations
├── Services            # Business logic services
├── Views               # Razor views (Books, Users, Transactions, Shared)
├── Program.cs          # Entry point
└── appsettings.json    # Configurations
```

---

## ⚙️ Installation & Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/AbdallahTaha1/LibraryManagementSystem.git
   cd LibraryManagementSystem
   ```

2. **Setup Database**
   Update the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Apply Migrations**

   ```bash
   dotnet ef database update
   ```

4. **Run the Project**

   ```bash
   dotnet run
   ```

5. Open in browser:

   ```
   https://localhost:5001
   ```
