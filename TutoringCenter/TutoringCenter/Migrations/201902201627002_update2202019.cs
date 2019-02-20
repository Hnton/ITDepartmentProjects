namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2202019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "StudentID", "dbo.Students");
            DropIndex("dbo.Logins", new[] { "StudentID" });
            AddColumn("dbo.Logins", "RealStudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Logins", "RealStudentID");
            AddForeignKey("dbo.Logins", "RealStudentID", "dbo.Students", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "RealStudentID", "dbo.Students");
            DropIndex("dbo.Logins", new[] { "RealStudentID" });
            DropColumn("dbo.Logins", "RealStudentID");
            CreateIndex("dbo.Logins", "StudentID");
            AddForeignKey("dbo.Logins", "StudentID", "dbo.Students", "ID");
        }
    }
}
