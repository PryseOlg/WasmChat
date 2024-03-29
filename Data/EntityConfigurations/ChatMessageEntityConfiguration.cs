﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASMChat.Data.Entities.Abstractions;
using WASMChat.Data.Entities.Chats;

namespace WASMChat.Data.EntityConfigurations;

public class ChatMessageEntityConfiguration: IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ReferencedMessage)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(m => m.ReferencedMessageId);
        
        builder.HasOne(x => x.Author)
            .WithMany(x => x.Messages);

        builder.Property(x => x.DateTimeSent)
            .ValueGeneratedOnAdd();

        builder.HasOne(x => x.Attachment)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(x => x.AttachmentId);

        builder.SoftDeletable();
    }
}