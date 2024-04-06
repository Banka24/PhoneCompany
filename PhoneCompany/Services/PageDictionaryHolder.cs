using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.View.Editor.Pages;
using PhoneCompany.View.Main.Pages;

namespace PhoneCompany.Services;

public static class PageDictionaryHolder
{
    private static readonly Dictionary<string, Page> Pages = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() },
        { "AddAbonentPage", new AddAbonentPage() },
        { "AddCityPage", new AddCityPage() },
        { "EditAbonentPage", new EditAbonentPage() },
        { "EditCityPage", new EditCityPage() },
        { "DeleteAbonentPage", new DeleteAbonentPage() },
        { "DeleteCityPage", new DeleteCityPage() },
    };

    public static Page GetPage(string namePage)
    {
        return Pages.TryGetValue(namePage, out var page) ? page : throw new KeyNotFoundException($"Страница с именем {namePage} не была найдена");
    }
}