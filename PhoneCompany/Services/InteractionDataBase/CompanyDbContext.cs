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
    /// Попытка сохранения данных в БД
    /// </summary>
    /// <returns>Результат успешности выполнения операции</returns>
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