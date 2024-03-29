﻿using System.ComponentModel;
using System.Security.Claims;
using MediatR;
using WASMChat.Shared.Requests.Abstractions;
using WASMChat.Shared.Results.Chats;

namespace WASMChat.Shared.Requests.Chats;

public record GetAllChatsRequest : 
    IRequest<GetAllChatsResult>,
    IUserRequest
{
    public ClaimsPrincipal? User { get; set; }
    [DefaultValue(0)]
    public required int Page { get; init; }
}