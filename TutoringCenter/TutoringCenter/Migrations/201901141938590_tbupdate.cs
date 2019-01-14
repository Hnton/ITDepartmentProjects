namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "CheckedIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logins", "CheckedOut", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "CheckedOut");
            DropColumn("dbo.Logins", "CheckedIn");
        }
    }
}
