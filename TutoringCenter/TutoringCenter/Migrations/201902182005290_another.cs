namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class another : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "StudentID", "dbo.Students");
            DropIndex("dbo.Logins", new[] { "StudentID" });
            AlterColumn("dbo.Logins", "StudentID", c => c.Int());
            CreateIndex("dbo.Logins", "StudentID");
            AddForeignKey("dbo.Logins", "StudentID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "StudentID", "dbo.Students");
            DropIndex("dbo.Logins", new[] { "StudentID" });
            AlterColumn("dbo.Logins", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Logins", "StudentID");
            AddForeignKey("dbo.Logins", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
        }
    }
}
