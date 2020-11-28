namespace SoDelivery.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeduserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "UserId", c => c.String());
            AddColumn("dbo.Contacts", "UserId", c => c.String());
            AddColumn("dbo.Tickets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "UserId");
            DropColumn("dbo.Contacts", "UserId");
            DropColumn("dbo.Availabilities", "UserId");
        }
    }
}
