# Legacy Customer Lookup Modernization Demo

This repository demonstrates the modernization of a legacy Windows Forms customer lookup application into a modern Blazor web application while sharing a common business/data layer.

The solution showcases:
- Legacy WinForms desktop application
- Modern Blazor web application
- Shared reusable data/service layer
- Basic customer search functionality
- Clean architecture separation
- .NET 8 modernization approach

---

# 🏗 Solution Structure

```text
LegacyCustomerLookup
│
├── CustomerLookup.Blazor
│   ├── Components
│   ├── Pages
│   ├── Program.cs
│   └── Blazor UI Application
│
├── CustomerLookup.WinForms
│   ├── Form1.cs
│   └── Legacy WinForms Application
│
├── CustomerLookup.Shared
│   ├── Data
│   │   └── CustomerService.cs
│   ├── Models
│   │   └── Customer.cs
│   └── Shared reusable business/data layer
│
└── LegacyCustomerLookup.sln
```

---

# Technologies Used

## Backend / Shared Layer
- C#
- .NET 8
- Shared Class Library
- Object-Oriented Design
- Dependency Injection

## Blazor Application
- Blazor Web App (.NET 8)
- Razor Components
- Component-Based Architecture

## WinForms Application
- Windows Forms
- DataGridView
- Event-driven desktop UI

## Tooling
- Git
- GitHub
- Visual Studio 2022
- .NET CLI
- PowerShell

---

# 🚀 Features

## WinForms Application
- Legacy desktop customer lookup screen
- Search customer records
- Display customer data in DataGridView
- Simulates traditional enterprise desktop systems

## Blazor Application
- Modern browser-based customer lookup
- Shared service layer with WinForms app
- Responsive component-based UI
- Demonstrates modernization strategy

## Shared Data Layer
- Reusable customer model
- Shared customer service
- Centralized mock data source
- Eliminates duplicated business logic
  
---

# Architecture Overview

The `CustomerLookup.Shared` project contains:
- Shared customer model
- Shared customer retrieval/search service
- Centralized business logic

Both applications consume the same shared service layer:

```text
WinForms UI
      │
      ▼
Shared CustomerService
      ▲
      │
Blazor UI
```

This demonstrates an enterprise modernization strategy where legacy desktop applications can gradually migrate to modern web technologies while preserving reusable backend logic.

---

# Application Screenshots

## WinForms Application

![WinForms UI](docs/images/winform-ui.png)

## Blazor Application

![Blazor UI](docs/images/blazor-ui.png)

---

# 📦 Getting Started

## 🧰 Prerequisites

Install the following tools before running the solution:

- .NET 8 SDK
- Visual Studio 2022
- Git

Verify .NET installation:

```powershell
dotnet --version
```

Expected output:

```text
8.x.x
```

# Build the Solution

## Open a terminal in the repository root folder and run:

```powershell
dotnet clean
dotnet build
```

# Running the Blazor Application

## ✅ Run the Blazor web application:

```powershell
dotnet run --project CustomerLookup.Blazor
```
Expected output:

```text
Now listening on: https://localhost:xxxx
```

Open the browser using the HTTPS URL displayed in the terminal.

Example:

```text
https://localhost:7185
```

# Running the WinForms Application

## ✅ Run the WinForms desktop application:

```powershell
dotnet run --project CustomerLookup.WinForms
```

This launches the legacy Windows Forms customer lookup application.


---

# Application Screenshots

## Blazor Customer Lookup

![Blazor Customer Lookup](docs/images/blazor-search.png)

Interactive Blazor Server customer lookup page supporting real-time search against SQL Server-backed customer data using Entity Framework Core and reusable shared service architecture.

---

## Legacy WinForms Customer Lookup

![WinForms Customer Lookup](docs/images/winforms-search.png)

Legacy Windows Forms implementation demonstrating the original desktop-based customer lookup workflow prior to modernization.

---

## SQL Server Customer Data

![SQL Server Customers Table](docs/images/sql-server-customers-table.png)

SQL Server persistence layer containing customer records consumed by both WinForms and Blazor applications through a shared Entity Framework Core DbContext and CustomerService layer.

---

# SQL Server Integration

The solution now includes SQL Server integration using Entity Framework Core and a shared reusable data access architecture.

## Features

- Shared Entity Framework Core DbContext
- SQL Server-backed customer persistence
- Reusable CustomerService consumed by both applications
- Interactive Blazor customer search functionality
- Dependency Injection across applications
- Shared business/data architecture
- Centralized customer retrieval logic
- Search filtering by:
  - Customer ID
  - First Name
  - Last Name
  - Email
  - Account Number

## Technologies Used

- SQL Server Express
- Entity Framework Core 8
- .NET 8
- Blazor Server
- Windows Forms
- Dependency Injection
- Shared Service Layer Architecture

---

## Architecture Overview

```text
WinForms UI
      │
      ▼
Shared CustomerService
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server Database
      ▲
      │
Blazor UI
```












