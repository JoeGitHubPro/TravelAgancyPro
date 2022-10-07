namespace TravelAgancyPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Subscription", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Subscription");
        }
    }
}
