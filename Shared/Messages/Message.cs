﻿namespace WASMChat.Shared.Messages;

public class Message
{
    public int Id { get; set; }
    
    public DateTime DateTimeSent { get; set; }
    
    public required string MessageText { get; set; }
    
    public ChatUser Author { get; set; }
    
    public Chat Chat { get; set; }
    
    
}