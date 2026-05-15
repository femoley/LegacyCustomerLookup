using CustomerLookup.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerLookup.Shared.Data
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        /*
        private readonly List<Customer> _customers =
    [
        new Customer { Id = 1, CustomerNumber = "C1001", Name = "Acme Financial", AccountType = "Checking", CurrentBalance = 15250.75m, Status = "Active" },
        new Customer { Id = 2, CustomerNumber = "C1002", Name = "Northlake Credit", AccountType = "Savings", CurrentBalance = 8420.10m, Status = "Active" },
        new Customer { Id = 3, CustomerNumber = "C1003", Name = "Legacy Loan Services", AccountType = "Loan", CurrentBalance = 250000m, Status = "Review" }
    ];

        public Task<List<Customer>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Task.FromResult(_customers);

            var result = _customers
                .Where(c =>
                    c.CustomerNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.AccountType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Task.FromResult(result);
        }
       */

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await _context.Customers.ToListAsync();

            return await _context.Customers
                .Where(c =>
                    c.FirstName.Contains(searchTerm) ||
                    c.LastName.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm) ||
                    c.AccountNumber.Contains(searchTerm))
                .ToListAsync();
        }

    }
}
