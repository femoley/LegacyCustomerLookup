using CustomerLookup.Shared.Data;

namespace CustomerLookup.WinForms;

public partial class CustomerSearch : Form
{
    private readonly CustomerService _customerService; //modified
    private TextBox _searchBox = new();
    private Button _searchButton = new();
    private DataGridView _grid = new();

    public CustomerSearch(CustomerService customerService) //added
    {
        InitializeComponent();
        _customerService = customerService; //added

        Text = "Legacy WinForms Customer Lookup";
        Width = 900;
        Height = 500;

        BuildLayout();

        Load += async (_, _) => await LoadCustomersAsync();
    }

    private void BuildLayout()
    {
        _searchBox.Left = 20;
        _searchBox.Top = 20;
        _searchBox.Width = 300;

        _searchButton.Left = 330;
        _searchButton.Top = 18; 
        _searchButton.Width = 100;
        _searchButton.Height = 30; //added
        _searchButton.Text = "Search";
        _searchButton.Click += async (_, _) => await LoadCustomersAsync();

        _grid.Left = 20;
        _grid.Top = 60;
        _grid.Width = 830;
        _grid.Height = 360;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.ReadOnly = true;
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;

        Controls.Add(_searchBox);
        Controls.Add(_searchButton);
        Controls.Add(_grid);
    }
    private async Task LoadCustomersAsync()
    {
        var customers = await _customerService.SearchAsync(_searchBox.Text);
        _grid.DataSource = customers;
    }
}
