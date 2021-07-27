namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeDescription2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipType", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipType", "Name");
        }
    }
}
