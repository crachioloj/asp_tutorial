namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String());
            AlterColumn("dbo.Customer", "Name", c => c.String());
        }
    }
}
