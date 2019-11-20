namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.WebUsers", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebUsers", "Name");
            DropColumn("dbo.Customers", "Name");
        }
    }
}
