namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerWebUsers",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        WebUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.WebUser_Id })
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.WebUsers", t => t.WebUser_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.WebUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerWebUsers", "WebUser_Id", "dbo.WebUsers");
            DropForeignKey("dbo.CustomerWebUsers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerWebUsers", new[] { "WebUser_Id" });
            DropIndex("dbo.CustomerWebUsers", new[] { "Customer_Id" });
            DropTable("dbo.CustomerWebUsers");
            DropTable("dbo.WebUsers");
            DropTable("dbo.Customers");
        }
    }
}
