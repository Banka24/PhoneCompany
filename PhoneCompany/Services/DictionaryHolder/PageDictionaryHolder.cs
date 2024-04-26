using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.Views.Main.Pages;

namespace PhoneCompany.Services.DictionaryHolder;

public class PageDictionaryHolder : DictionaryHolderBase
{
    private readonly Dictionary<string, Page> _pages = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() },
    };

    public override Page GetPage(string namePage)
    {
        return _pages.TryGetValue(namePage, out var page) ? page : throw new KeyNotFoundException($"Страница с именем {namePage} не была найдена");
    }
}