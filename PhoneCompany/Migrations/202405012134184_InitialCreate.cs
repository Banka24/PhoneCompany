namespace PhoneCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Inn = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbonentId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NumberOfMinutes = c.Int(nullable: false),
                        TimeOfDay = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abonents", t => t.AbonentId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.AbonentId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        TariffDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TariffNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conversations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Conversations", "AbonentId", "dbo.Abonents");
            DropIndex("dbo.Conversations", new[] { "CityId" });
            DropIndex("dbo.Conversations", new[] { "AbonentId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Conversations");
            DropTable("dbo.Abonents");
        }
    }
}
