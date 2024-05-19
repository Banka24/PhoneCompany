namespace PhoneCompany.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Services.InteractionDataBase.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PhoneCompany.Services.InteractionDataBase.CompanyDbContext";
        }
    }
}
