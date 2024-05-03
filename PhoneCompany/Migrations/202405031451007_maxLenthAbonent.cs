namespace PhoneCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxLenthAbonent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abonents", "Inn", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abonents", "Inn", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
