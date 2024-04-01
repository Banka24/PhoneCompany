using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public class ConversationService : InteractionService
{
    public async Task<IEnumerable<Conversation>> GetDataAsync()
    {
        return await Context.Conversations.ToListAsync();
    }
}