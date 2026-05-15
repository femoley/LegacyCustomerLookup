namespace CustomerLookup.Shared.Models;
public class Customer
{
    /*
    public int Id { get; set; }
    public string CustomerNumber { get; set; } = "";
    public string Name { get; set; } = "";
    public string AccountType { get; set; } = "";
    public decimal CurrentBalance { get; set; }
    public string Status { get; set; } = "";
    */

    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string AccountNumber { get; set; } = "";
}
