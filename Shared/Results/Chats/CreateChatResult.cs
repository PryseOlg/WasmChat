﻿using WASMChat.Shared.Models.Chats;

namespace WASMChat.Shared.Results.Chats;

public record CreateChatResult
{
    public required ChatModel Chat { get; init; }
}