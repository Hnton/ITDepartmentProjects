namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "CheckedOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "CheckedOut", c => c.DateTime(nullable: false));
        }
    }
}
