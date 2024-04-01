using System.Data.Entity;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public class CompanyDbContext() : DbContext("PhoneCompany")
{
    public DbSet<Abonent> Abonents { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<TimeOfDay> TimeOfDays { get; set; }
}