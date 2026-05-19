using System.Text.RegularExpressions;
using CustomerLookup.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerLookup.Shared.Data
{
    public class CustomerService
    {
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
       
       
		private readonly ApplicationDbContext _context;
	
	    public CustomerService(ApplicationDbContext context)
	    {
			_context = context;
	    }

	    public async Task<List<Customer>> SearchAsync(string searchTerm)
	    {
			if (string.IsNullOrWhiteSpace(searchTerm))
				return await _context.Customers.ToListAsync();

			return await _context.Customers
				.Where(c =>
				c.Id.ToString().Contains(searchTerm) ||
				c.FirstName.Contains(searchTerm) ||
				c.LastName.Contains(searchTerm) ||
				c.Email.Contains(searchTerm) ||
				c.AccountNumber.Contains(searchTerm))
				.ToListAsync();
	    }

	    public async Task<(bool Success, string Message)> UpdateEmailAsync(int customerId, string newEmail)
	    {
			if (string.IsNullOrWhiteSpace(newEmail))
				return (false, "Email address is required.");

			newEmail = newEmail.Trim();

			if (!IsValidEmail(newEmail))
				return (false, "Please enter a valid email address.");

			var emailExists = await _context.Customers
				.AnyAsync(c => c.Email == newEmail && c.Id != customerId);

			if (emailExists)
				return (false, "This email address already exists for another customer.");

			var customer = await _context.Customers.FindAsync(customerId);

			if (customer is null)
				return (false, "Customer was not found.");

			customer.Email = newEmail;

			try
			{
				await _context.SaveChangesAsync();
				return (true, "Email address updated successfully.");
			}
			catch (DbUpdateException)
			{
				return (false, "Unable to update email. The email address may already exist.");
			}
	    }

        public async Task<(bool Success, string Message)> UpdateEmailsAsync(Dictionary<int, string> emailUpdates)
        {
            if (emailUpdates == null || !emailUpdates.Any())
                return (false, "No email updates were submitted.");

            var cleanedUpdates = emailUpdates
                .ToDictionary(x => x.Key, x => x.Value.Trim());

            foreach (var update in cleanedUpdates)
            {
                if (string.IsNullOrWhiteSpace(update.Value))
                    return (false, "Email address is required.");

                if (!IsValidEmail(update.Value))
                    return (false, $"Invalid email address: {update.Value}");
            }

            var duplicateEmailsInRequest = cleanedUpdates
                .GroupBy(x => x.Value.ToLower())
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateEmailsInRequest.Any())
                return (false, $"Duplicate email entered: {duplicateEmailsInRequest.First()}");

            var customerIds = cleanedUpdates.Keys.ToList();
            var newEmails = cleanedUpdates.Values.Select(e => e.ToLower()).ToList();

            var existingEmailConflict = await _context.Customers
                .AnyAsync(c =>
                    newEmails.Contains(c.Email.ToLower()) &&
                    !customerIds.Contains(c.Id));

            if (existingEmailConflict)
                return (false, "One or more email addresses already exist for another customer.");

            var customers = await _context.Customers
                .Where(c => customerIds.Contains(c.Id))
                .ToListAsync();

            foreach (var customer in customers)
            {
                customer.Email = cleanedUpdates[customer.Id];
            }

            try
            {
                await _context.SaveChangesAsync();
                return (true, "Email updates saved successfully.");
            }
            catch (DbUpdateException)
            {
                return (false, "Unable to save updates. One or more email addresses may already exist.");
            }
        }

        private static bool IsValidEmail(string email)
	    {
		return Regex.IsMatch(
		    email,
		    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		    RegexOptions.IgnoreCase);
    	}

    }
}
