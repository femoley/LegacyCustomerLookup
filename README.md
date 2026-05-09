# LegacyCustomerLookup Modernization Demo

This repository demonstrates the modernization of a legacy Windows Forms customer lookup application into a modern Blazor web application while sharing a common business/data layer.

The solution showcases:
- Legacy WinForms desktop application
- Modern Blazor web application
- Shared reusable data/service layer
- Basic customer search functionality
- Clean architecture separation
- .NET 8 modernization approach

---

# Solution Structure

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

# Application Screenshots

## WinForms Application

![WinForms UI](docs/images/winform-ui.png)

## Blazor Application

![Blazor UI](docs/images/blazor-ui.png)


