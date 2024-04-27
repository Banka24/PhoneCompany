using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Models;

namespace PhoneCompany.Services.InteractionDataBase;
/// <summary>
///  Сервис работы с таблицей Переговоры
/// </summary>
public class ConversationService(CompanyDbContext context)
{
    private static Conversation _lastFoundConversation;

    /// <summary>
    /// Получение списка переговоров
    /// </summary>
    /// <returns>Список переговоров</returns>
    public async Task<IEnumerable<Conversation>> GetDataAsync()
    {
        var conversation = await context.Conversations.ToListAsync();
        context = null;
        return conversation;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Conversation>> GetDataAsync(string phoneNumber)
    {
        var conversation = await context.Conversations.Where(i => i.Abonent.PhoneNumber == phoneNumber).ToListAsync();
        context = null;
        return conversation;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<bool> AddConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            context.Conversations.Add(await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay));
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task GetConversationAsync(string phoneNumber, string titleCity, DateTime dateTime)
    {
       _lastFoundConversation = await context.Conversations.FirstOrDefaultAsync(i => i.Abonent.PhoneNumber == phoneNumber && i.City.Title == titleCity && i.Date == dateTime)
               ?? throw new Exception("Такого номера нет");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<bool> EditConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            await GetConversationAsync(phoneNumber, title, date);

            context.Conversations.Attach(_lastFoundConversation);
            var newConversation = await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay);

            (_lastFoundConversation.AbonentId, _lastFoundConversation.CityId, _lastFoundConversation.Date, _lastFoundConversation.NumberOfMinutes, _lastFoundConversation.TimeOfDayId) =
                (newConversation.AbonentId, newConversation.CityId, newConversation.Date, newConversation.NumberOfMinutes, newConversation.TimeOfDayId);

            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> DeleteConversationAsync(string phoneNumber, string titleCity, DateTime dateTime)
    {
        using (context)
        {
            var conversation = await context.Conversations.FirstOrDefaultAsync(i => i.Abonent.PhoneNumber == phoneNumber && i.City.Title == titleCity && i.Date == dateTime) 
                               ?? throw new Exception("Такого элемента нет");
            context.Conversations.Remove(conversation);
            return await context.TrySaveChangeAsync();
        }
    }

    private async Task<Conversation> MakeConversation(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        var con = new Conversation
        {
            AbonentId = await context.Abonents.Where(i => i.PhoneNumber == phoneNumber).Select(i => i.Id).SingleOrDefaultAsync(),
            CityId = await context.Cities.Where(i => i.Title == title).Select(i => i.Id).FirstOrDefaultAsync(),
            Date = date,
            NumberOfMinutes = numberOfMinutes,
            TimeOfDayId = await context.TimeOfDays.Where(i => i.Title == timeOfDay).Select(i => i.Id).SingleOrDefaultAsync()
        };
        return con;
    }
}