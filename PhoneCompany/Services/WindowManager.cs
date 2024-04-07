using PhoneCompany.View.Editor.Windows;
using System.Text;

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
        var window = new Editor(PageDictionaryHolder.GetPage(pageName));
        window.ShowDialog();
    }
}