namespace bankproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Transcations", "AccountNumber");
            AddForeignKey("dbo.Transcations", "AccountNumber", "dbo.Accounts", "AccountNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transcations", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transcations", new[] { "AccountNumber" });
        }
    }
}
