﻿using WASMChat.Data.Entities.Chats;
using WASMChat.Shared.Models.Chats;

namespace WASMChat.Server.Mappers.Chats;

public class ChatMessageModelMapper : IMapper
{
    private readonly ChatUserModelMapper _userModelMapper;

    public ChatMessageModelMapper(ChatUserModelMapper userModelMapper)
    {
        _userModelMapper = userModelMapper;
    }

    public ChatMessageModel Create(ChatMessage message)
    {
        return new ChatMessageModel
        {
            Id = message.Id,
            ChatId = message.ChatId,
            AttachmentId = message.AttachmentId,
            ReferencedMessageId = message.ReferencedMessageId,
            SentTime = message.DateTimeSent,
            Text = message.MessageText,
            Author = _userModelMapper.Create(message.Author!)
        };
    }
}