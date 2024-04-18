using PhoneCompany.View.Editor.Windows;
using System.Text;
using PhoneCompany.Services.DictionaryHolder;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.Services;

public static class WindowManager
{
    private static string GetPageName(in string nameCommand, in string nameCallingPage)
    {
        var sb = new StringBuilder(nameCommand);
        return $"{sb.Append(nameCallingPage)}";
    }

    public static void OpenWindow(in string nameCommand, in string nameCallingPage)
    {
        var pageName = GetPageName(nameCommand, nameCallingPage);
        var pageHolder = new EditorPageDictionaryHolder();
        var window = new Editor(pageHolder.GetPage(pageName));
        if (window.ShowDialog() is false)
        {
            EditorViewModel.CurrentPage = null;
        }
    }
}