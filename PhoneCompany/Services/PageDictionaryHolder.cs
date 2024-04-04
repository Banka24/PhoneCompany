using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.View.Pages;

namespace PhoneCompany.Services;

public static class PageDictionaryHolder
{
    private static readonly Dictionary<string, Page> Pages = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() },
        { "AddAbonentPage", new AddAbonentPage() }
    };

    public static Page GetPage(string namePage)
    {
        return Pages.TryGetValue(namePage, out var page) ? page : throw new KeyNotFoundException($"Страница с именем {namePage} не была найдена");
    }
}