class Outlay
{
    public string? PruductName { get; set; }
    public long ProductPrice { get; set; }
    public long UserChatId { get; set; }
    public string? UserName { get; set; }

    public DateTime CreatedTime;


    public void SaveOutlay(long chatId, string productName, int productPrice)
    {
        UserChatId = chatId;
        PruductName = productName;
        ProductPrice = productPrice;
        CreatedTime = DateTime.Now;
    }

    public string ShowOutlay(long chatId, string productName, int productPrice)
    {
        return $"User login: {chatId},  " +
            $"\nProduct Name: {productName},  " +
            $"\nProduct price: {productPrice},  " +
            $"\nDate time: {CreatedTime}";
    }
}

