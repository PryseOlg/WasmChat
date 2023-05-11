﻿using Microsoft.EntityFrameworkCore;
using WASMChat.Data.Entities.Chats;

namespace WASMChat.Data.Repositories;

public class ChatRepository : RepositoryBase<Chat>
{
    private const int ChatsPerPage = 10;
    
    public ChatRepository(DbContext ctx) : base(ctx)
    { }

    public async ValueTask<Chat?> GetChatByIdAsync(int id) => await Set
        .Include(x => x.ChatUsers)
        .Include(x => x.Messages.Take(100))
        .ThenInclude(x => x.Author)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<Chat> SaveChatAsync(Chat chat)
    {
        Set.Add(chat);
        await CommitAsync();
        return chat;
    }

    public async ValueTask<IReadOnlyCollection<Chat>> GetChats(int userId, int page = 0) => await Set
        .Where(c => c.ChatUsers.Any(u => u.Id == userId))
        .Include(c => c.Messages.OrderBy(m => m.DateTimeSent).Take(1))
        .ThenInclude(m => m.Author)
        .OrderBy(c => c.Id)
        .Skip(ChatsPerPage * page)
        .Take(ChatsPerPage)
        .ToArrayAsync();

    public async ValueTask<IReadOnlyCollection<int>> GetAllChatIds(int userId) => await Set
        .Where(c => c.ChatUsers.Any(u => u.Id == userId))
        .Select(c => c.Id)
        .ToArrayAsync();

}