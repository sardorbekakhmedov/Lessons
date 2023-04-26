class Outlay
{
    public string? PruductName { get; set; }
    public int? ProductPrice { get; set; }

    public long ChatId;

    public DateTime CreateTime;


    public void SaveOutlay(long chatId, string productName, int productPrice)
    {
        ChatId = chatId;
        PruductName = productName;
        ProductPrice = productPrice;
        CreateTime = DateTime.Now;
    }

    public string ShowOutlay(long chatId, string productName, int productPrice)
    {
        return $"User login: {chatId},  " +
            $"\nProduct Name: {productName},  " +
            $"\nProduct price: {productPrice},  " +
            $"\nDate time: {CreateTime}";
    }
}