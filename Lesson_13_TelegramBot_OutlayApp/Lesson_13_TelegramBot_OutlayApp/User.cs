class User
{
    public long ChatId { get; set; }
    public string? Name { get; set; }
    public ENextMessage NextMessage { get; set; }
    public Outlay? CurrentAddingOutlay { get; set; }
    public Room? CurrentRoom { get; set; }
    public List<string>? MyRooms;
}