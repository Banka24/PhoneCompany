using System.Windows.Controls;

namespace PhoneCompany.Services.DictionaryHolder
{
    public abstract class DictionaryHolderBase
    {
        /// <summary>
        /// Получение страницы по названию
        /// </summary>
        /// <param name="namePage">Название страницы</param>
        /// <returns>Страница по полученному названию</returns>
        public abstract Page GetPage(string namePage);
    }
}
