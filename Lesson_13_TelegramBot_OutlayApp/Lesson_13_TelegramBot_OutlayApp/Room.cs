class Room
{
    public long OwnerChatId { get; set; }
    public string? Name { get; set; }
    public List<Outlay>? Outlays { get; set; }
    public List<long>? UserIds { get; set; }


    public string GetShowRoom(long ownerChatId, string? name, List<Outlay>? outlays, List<long>? userIds)
    {
        return $"Owner:  {ownerChatId}" +
            $"\nRom name:  {name}" +
            $"\nOutlays count:  {outlays!.Count}" +
            $"\nUsers count:  {userIds!.Count} ";
    }
}