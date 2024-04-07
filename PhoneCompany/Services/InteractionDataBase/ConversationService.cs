﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class ConversationService(CompanyDbContext context)
{
    public async Task<IEnumerable<Conversation>> GetDataAsync()
    {
        return await context.Conversations.ToListAsync();
    }
}