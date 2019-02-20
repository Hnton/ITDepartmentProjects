namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HELPPP : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "StudentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "StudentID", c => c.Int(nullable: false));
        }
    }
}
