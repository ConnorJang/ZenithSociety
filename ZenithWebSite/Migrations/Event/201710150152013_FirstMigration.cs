namespace ZenithWebSite.Migrations.Event
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivityCategories", "ActivityDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActivityCategories", "ActivityDescription", c => c.String());
        }
    }
}
