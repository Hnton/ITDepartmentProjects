namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update282019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        R_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.R_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReasonLogins",
                c => new
                    {
                        Reason_R_ID = c.Int(nullable: false),
                        Login_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reason_R_ID, t.Login_ID })
                .ForeignKey("dbo.Reasons", t => t.Reason_R_ID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .Index(t => t.Reason_R_ID)
                .Index(t => t.Login_ID);
            
            AddColumn("dbo.Logins", "Student_ID", c => c.Int());
            CreateIndex("dbo.Logins", "Student_ID");
            AddForeignKey("dbo.Logins", "Student_ID", "dbo.Students", "ID");
            DropColumn("dbo.Logins", "StudentID");
            DropColumn("dbo.Logins", "VisitReason");
            DropColumn("dbo.Logins", "Subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Subject", c => c.String());
            AddColumn("dbo.Logins", "VisitReason", c => c.String());
            AddColumn("dbo.Logins", "StudentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Logins", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.ReasonLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.ReasonLogins", "Reason_R_ID", "dbo.Reasons");
            DropIndex("dbo.ReasonLogins", new[] { "Login_ID" });
            DropIndex("dbo.ReasonLogins", new[] { "Reason_R_ID" });
            DropIndex("dbo.Logins", new[] { "Student_ID" });
            DropColumn("dbo.Logins", "Student_ID");
            DropTable("dbo.ReasonLogins");
            DropTable("dbo.Students");
            DropTable("dbo.Reasons");
        }
    }
}
