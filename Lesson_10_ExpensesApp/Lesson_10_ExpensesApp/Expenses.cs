struct Expenses
{
    public string ProductName;
    public int ProductPrice;
    public string UserLogin;

    public void ShowUsers(string userLogin, string productName, int productPrice)
    {
        Console.WriteLine($"User login: {userLogin},  Product Name: {productName},  Product price: {productPrice}");
    }

    public void SaveExpenses (string productName, int productPrice, string userLogin)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        UserLogin = userLogin;
    }
}
