namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus2152019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reasons", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Status");
            DropColumn("dbo.Reasons", "Status");
        }
    }
}
