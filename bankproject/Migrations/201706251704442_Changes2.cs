namespace bankproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false));
        }
    }
}
