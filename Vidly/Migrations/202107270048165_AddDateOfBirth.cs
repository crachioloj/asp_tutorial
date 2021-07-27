namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "DateOfBirth");
        }
    }
}
