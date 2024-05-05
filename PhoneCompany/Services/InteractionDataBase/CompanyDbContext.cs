using System;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Models;

namespace PhoneCompany.Services.InteractionDataBase;

/// <summary>
/// Контекст подключения к Базе Данных
/// </summary>
public class CompanyDbContext() : DbContext("PhoneCompany")
{
    public DbSet<Abonent> Abonents { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Conversation> Conversations { get; set; }

    /// <summary>
    /// Асинхронная попытка сохранения данных в БД
    /// </summary>
    /// <returns>Вернёт true если получилось сохранить изменения, false если произошла ошибка</returns>
    public async Task<bool> TrySaveChangeAsync()
    {
        try
        {
            await SaveChangesAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}