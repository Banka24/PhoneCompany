﻿using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Models;
using System.Linq;

namespace PhoneCompany.Services.InteractionDataBase;

internal class ContextInitializer : DropCreateDatabaseAlways<CompanyDbContext>
{
    protected override async void Seed(CompanyDbContext context)
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

        await context.TrySaveChangeAsync();
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