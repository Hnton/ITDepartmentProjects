namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reasons", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String());
            AlterColumn("dbo.Reasons", "Name", c => c.String());
        }
    }
}
