namespace bankproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfAccount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Transcations",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transcations");
            DropTable("dbo.Accounts");
        }
    }
}
