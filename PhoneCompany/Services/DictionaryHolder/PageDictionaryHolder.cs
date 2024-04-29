using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.Views.Main.Pages;

namespace PhoneCompany.Services.DictionaryHolder;
/// <summary>
/// Словарь страниц главного окна
/// </summary>
public class PageDictionaryHolder : DictionaryHolderBase
{
    protected override Dictionary<string, Page> Pages { get; } = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() },
    };
}