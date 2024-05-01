using System.Collections.Generic;
using System.Windows.Controls;

namespace PhoneCompany.Services.DictionaryHolder;

/// <summary>
/// Базовый класс для Держателей словарей
/// </summary>
public abstract class DictionaryHolderBase
{
    protected virtual Dictionary<string, Page> Pages { get; } = [];

    /// <summary>
    /// Нахождение страницы по названию в словаре
    /// </summary>
    /// <returns>Страница по полученному названию</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public Page GetPage(string namePage)
    {
        return Pages.TryGetValue(namePage, out var page) ? page : throw new KeyNotFoundException($"Страница с именем {namePage} не была найдена");
    }
}