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
    /// Получить список переговоров по номеру телефона
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns>Список телефонных переговоров</returns>
    public async Task<IEnumerable<Conversation>> GetDataByPhoneNumberAsync(string phoneNumber)
    {
        var conversation = await context.Conversations.Where(i => i.Abonent.PhoneNumber == phoneNumber).ToListAsync();
        context = null;
        return conversation;
    }

    /// <summary>
    /// Асинхронное добавление разговора в базу данных
    /// </summary>
    /// <returns>Результат успешности выполнения операции</returns>
    public async Task<bool> AddConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            context.Conversations.Add(await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay));
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное редактирование информации о разговоре
    /// </summary>
    /// <returns>Результат успешности выполнения операции</returns>
    public async Task<bool> EditConversationAsync(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        using (context)
        {
            await FindConversationAsync(phoneNumber, title, date);

            context.Conversations.Attach(_lastFoundConversation);
            var newConversation = await MakeConversation(phoneNumber, title, date, numberOfMinutes, timeOfDay);

            (_lastFoundConversation.AbonentId, _lastFoundConversation.CityId, _lastFoundConversation.Date, _lastFoundConversation.NumberOfMinutes, _lastFoundConversation.TimeOfDay) =
                (newConversation.AbonentId, newConversation.CityId, newConversation.Date, newConversation.NumberOfMinutes, newConversation.TimeOfDay);

            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное удаление разговора из базы данных
    /// </summary>
    /// <returns>Результат успешности выполнения операции</returns>
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

    private async Task FindConversationAsync(string phoneNumber, string titleCity, DateTime dateTime)
    {
        _lastFoundConversation = await context.Conversations.FirstOrDefaultAsync(i => i.Abonent.PhoneNumber == phoneNumber && i.City.Title == titleCity && i.Date == dateTime)
                                 ?? throw new Exception("Такого номера нет");
    }

    private async Task<Conversation> MakeConversation(string phoneNumber, string title, DateTime date, int numberOfMinutes, string timeOfDay)
    {
        return new Conversation
        {
            AbonentId = await context.Abonents.Where(i => i.PhoneNumber == phoneNumber).Select(i => i.Id).SingleOrDefaultAsync(),
            CityId = await context.Cities.Where(i => i.Title == title).Select(i => i.Id).FirstOrDefaultAsync(),
            Date = date,
            NumberOfMinutes = numberOfMinutes,
            TimeOfDay = timeOfDay
        };
    }
}