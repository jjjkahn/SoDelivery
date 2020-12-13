namespace SoDelivery.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String());
            DropColumn("dbo.Accounts", "AccountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "AccountType", c => c.String());
            DropColumn("dbo.Accounts", "Name");
        }
    }
}
