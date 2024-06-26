﻿using System.Collections.Generic;
using System.Windows.Controls;
using PhoneCompany.Views.Editor.Pages;

namespace PhoneCompany.Services.DictionaryHolder;

/// <summary>
/// Словаря страниц редактора
/// </summary>
public class EditorPageDictionaryHolder : DictionaryHolderBase
{
    protected override Dictionary<string, Page> Pages { get; } = new()
    {
        { "AddAbonentPage", new AddAbonentPage() },
        { "AddCityPage", new AddCityPage() },
        { "EditAbonentPage", new EditAbonentPage() },
        { "EditCityPage", new EditCityPage() },
        { "DeleteAbonentPage", new DeleteAbonentPage() },
        { "DeleteCityPage", new DeleteCityPage() },
        { "AddConversationPage", new AddConversation() },
        { "EditConversationPage", new EditConversation() },
        { "DeleteConversationPage", new DeleteConversation() }
    };
}