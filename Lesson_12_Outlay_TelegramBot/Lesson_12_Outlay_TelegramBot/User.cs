﻿class User
{
    public long ChatId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public List<Outlay> outlays { get; set; }
    public ENextMessage NextMessage { get; set;  }
}