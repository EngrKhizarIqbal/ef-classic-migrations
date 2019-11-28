namespace EF6Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerWebUser",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        WebUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.WebUser_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.WebUser", t => t.WebUser_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.WebUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerWebUser", "WebUser_Id", "dbo.WebUser");
            DropForeignKey("dbo.CustomerWebUser", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.CustomerWebUser", new[] { "WebUser_Id" });
            DropIndex("dbo.CustomerWebUser", new[] { "Customer_Id" });
            DropTable("dbo.CustomerWebUser");
            DropTable("dbo.WebUser");
            DropTable("dbo.Customer");
        }
    }
}
