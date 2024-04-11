using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class ConversationService(CompanyDbContext context)
{
    private static Conversation _lastFoundConversation;

    public async Task<IEnumerable<Conversation>> GetDataAsync()
    {
        var conversation = await context.Conversations.ToListAsync();
        context = null;
        return conversation;
    }

    public async Task<bool> AddConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            context.Conversations.Add(await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay));
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<Conversation> GetConversationAsync(string phoneNumber)
    {
        using (context)
        {
            _lastFoundConversation = await context.Conversations.FirstOrDefaultAsync(i => i.Abonent.PhoneNumber == phoneNumber) ?? throw new Exception("Такого номера нет");
            return _lastFoundConversation;
        }
    }

    public async Task<bool> EditConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            context.Conversations.Attach(_lastFoundConversation);
            _lastFoundConversation = await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay);
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<bool> DeleteConversationAsync(string phoneNumber)
    {
        using (context)
        {
            var conversation = await context.Conversations.FirstOrDefaultAsync(i => i.Abonent.PhoneNumber == phoneNumber) ?? throw new Exception("Такого элемента нет");
            context.Conversations.Remove(conversation);
            return await context.TrySaveChangeAsync();
        }
    }

    private async Task<Conversation> MakeConversation(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        var con = new Conversation
        {
            AbonentId = await context.Abonents.Where(i => i.PhoneNumber == phoneNumber).Select(i => i.Id).SingleOrDefaultAsync(),
            CityId = await context.Cities.Where(i => i.Title == title).Select(i => i.Id).SingleOrDefaultAsync(),
            Date = date,
            NumberOfMinutes = numberOfMinutes,
            TimeOfDayId = await context.TimeOfDays.Where(i => i.Title == timeOfDay).Select(i => i.Id).SingleOrDefaultAsync()
        };
        return con;
    }
}