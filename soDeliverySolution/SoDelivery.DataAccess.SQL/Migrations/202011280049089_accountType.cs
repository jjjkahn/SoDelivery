namespace SoDelivery.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AccountTypep_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AccountTypep_Id");
            AddForeignKey("dbo.Customers", "AccountTypep_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AccountTypep_Id", "dbo.Accounts");
            DropIndex("dbo.Customers", new[] { "AccountTypep_Id" });
            DropColumn("dbo.Customers", "AccountTypep_Id");
        }
    }
}
