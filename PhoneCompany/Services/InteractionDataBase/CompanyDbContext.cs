﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Models;

namespace PhoneCompany.Services.InteractionDataBase;

public class CompanyDbContext() : DbContext("PhoneCompany")
{
    public DbSet<Abonent> Abonents { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<TimeOfDay> TimeOfDays { get; set; }

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