namespace CustomerLookup.Shared.Models;
public class Customer
{
    public int Id { get; set; }
    public string CustomerNumber { get; set; } = "";
    public string Name { get; set; } = "";
    public string AccountType { get; set; } = "";
    public decimal CurrentBalance { get; set; }
    public string Status { get; set; } = "";
}
