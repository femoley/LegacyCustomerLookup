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