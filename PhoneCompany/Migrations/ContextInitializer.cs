using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Models;
using System.Linq;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.Migrations;

internal class ContextInitializer : DropCreateDatabaseAlways<CompanyDbContext>
{
    protected override void Seed(CompanyDbContext context)
    {
        context.TimeOfDays.AddRange(
        [
            new TimeOfDay
            {
                Title = "День"
            },
            new TimeOfDay
            {
                Title = "Ночь"
            }
        ]);

        context.SaveChanges();
    }

    public Task MakeSeed()
    {
        Task.Run(() =>
        {
            var context = new CompanyDbContext();

            if (!context.TimeOfDays.Any())
            {
                Seed(context);
            }

            context.Dispose();
        });

        return Task.CompletedTask;
    }
}