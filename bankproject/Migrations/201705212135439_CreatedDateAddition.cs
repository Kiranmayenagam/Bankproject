namespace bankproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDateAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "CreatedDate");
        }
    }
}
