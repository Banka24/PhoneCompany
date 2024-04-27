using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.Views.Main.Pages;

namespace PhoneCompany.Services.DictionaryHolder;
/// <summary>
/// Держатель словаря страниц главного окна
/// </summary>
public class PageDictionaryHolder : DictionaryHolderBase
{
    /// <summary>
    /// Словарь страниц главного окна
    /// </summary>
    protected override Dictionary<string, Page> Pages { get; } = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() },
    };
}