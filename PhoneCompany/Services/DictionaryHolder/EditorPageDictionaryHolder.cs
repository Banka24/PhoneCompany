using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.Views.Editor.Pages;

namespace PhoneCompany.Services.DictionaryHolder;

public class EditorPageDictionaryHolder : DictionaryHolderBase
{
    private readonly Dictionary<string, Page> _pages = new()
    {
        { "AddAbonentPage", new AddAbonentPage() },
        { "AddCityPage", new AddCityPage() },
        { "EditAbonentPage", new EditAbonentPage() },
        { "EditCityPage", new EditCityPage() },
        { "DeleteAbonentPage", new DeleteAbonentPage() },
        { "DeleteCityPage", new DeleteCityPage() },
        { "AddConversationPage", new AddConversation() },
        { "EditConversationPage", new EditConversation() },
        { "DeleteConversationPage", new DeleteConversation() },
    };

    public override Page GetPage(string namePage)
    {
        return _pages.TryGetValue(namePage, out var page) ? page : throw new KeyNotFoundException($"Страница с именем {namePage} не была найдена");
    }
}