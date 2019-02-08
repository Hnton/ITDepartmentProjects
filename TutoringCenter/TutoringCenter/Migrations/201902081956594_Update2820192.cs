namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2820192 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        S_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.S_ID);
            
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
            DropIndex("dbo.SubjectLogins", new[] { "Login_ID" });
            DropIndex("dbo.SubjectLogins", new[] { "Subject_S_ID" });
            DropTable("dbo.SubjectLogins");
            DropTable("dbo.Subjects");
        }
    }
}
