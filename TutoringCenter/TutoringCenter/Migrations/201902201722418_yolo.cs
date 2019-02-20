namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yolo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logins", "StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "StudentID", c => c.Int());
        }
    }
}
