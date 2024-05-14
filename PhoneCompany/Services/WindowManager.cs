using System.Text;
using System.Windows.Controls;
using PhoneCompany.Services.DictionaryHolder;
using PhoneCompany.ViewModels.EditorVM;
using PhoneCompany.Views.Editor.Windows;

namespace PhoneCompany.Services;

/// <summary>
///     Менеджер по управлению окнами
/// </summary>
public static class WindowManager
{
    /// <summary>
    ///     Открытие редактора по названию команды и названию с вызываемой страницы
    /// </summary>
    public static void OpenEditor(in string nameCommand, in string nameCallingPage)
    {
        var window = new Editor(OpenPage(nameCommand, nameCallingPage));
        if (window.ShowDialog() is false)
        {
            EditorViewModel.CurrentPage = null;
        }
    }

    private static Page OpenPage(in string nameCommand, in string nameCallingPage)
    {
        var pageName = GetNamePageToOpen(nameCommand, nameCallingPage);
        var pageHolder = new EditorPageDictionaryHolder();
        return pageHolder.GetPage(pageName);
    }

    private static string GetNamePageToOpen(in string nameCommand, in string nameCallingPage)
    {
        var sb = new StringBuilder(nameCommand);
        return $"{sb.Append(nameCallingPage)}";
    }
}