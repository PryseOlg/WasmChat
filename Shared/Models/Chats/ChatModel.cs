﻿namespace WASMChat.Shared.Models.Chats;

public record ChatModel
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required int AvatarId { get; init; }
    public required ChatUserModel[] Users { get; init; }
    public required ChatMessageModel[] Messages { get; init; }
}