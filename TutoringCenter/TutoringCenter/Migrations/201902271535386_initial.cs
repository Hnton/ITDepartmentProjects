namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CheckedIn = c.DateTime(nullable: false),
                        CheckedOut = c.DateTime(),
                        RealStudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.RealStudentID, cascadeDelete: true)
                .Index(t => t.RealStudentID);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        R_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
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
                "dbo.Subjects",
                c => new
                    {
                        S_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.S_ID);
            
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
            
            CreateTable(
                "dbo.SubjectLogins",
                c => new
                    {
                        Subject_S_ID = c.Int(nullable: false),
                        Login_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_S_ID, t.Login_ID })
                .ForeignKey("dbo.Subjects", t => t.Subject_S_ID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .Index(t => t.Subject_S_ID)
                .Index(t => t.Login_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.SubjectLogins", "Subject_S_ID", "dbo.Subjects");
            DropForeignKey("dbo.Logins", "RealStudentID", "dbo.Students");
            DropForeignKey("dbo.ReasonLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.ReasonLogins", "Reason_R_ID", "dbo.Reasons");
            DropIndex("dbo.SubjectLogins", new[] { "Login_ID" });
            DropIndex("dbo.SubjectLogins", new[] { "Subject_S_ID" });
            DropIndex("dbo.ReasonLogins", new[] { "Login_ID" });
            DropIndex("dbo.ReasonLogins", new[] { "Reason_R_ID" });
            DropIndex("dbo.Logins", new[] { "RealStudentID" });
            DropTable("dbo.SubjectLogins");
            DropTable("dbo.ReasonLogins");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Reasons");
            DropTable("dbo.Logins");
        }
    }
}
