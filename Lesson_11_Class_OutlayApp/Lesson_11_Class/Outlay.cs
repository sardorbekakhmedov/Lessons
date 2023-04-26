class Outlay
{
    public string ProductName;
    public int ProductPrice;
    public string UserLogin;
    public DateTime CreateTime;

    public void SaveOutlay (string productName, int productPrice, string userLogin)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        UserLogin = userLogin;
        CreateTime = DateTime.Now;
    }

    public void ShowOutlay(string userLogin, string productName, int productPrice)
    {
        Console.WriteLine($"User login: {userLogin},  Product Name: {productName},  Product price: {productPrice},  " +
            $"Date time: {CreateTime}");
    }
}


