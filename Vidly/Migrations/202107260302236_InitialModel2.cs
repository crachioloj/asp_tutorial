namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipType");
            RenameTable(name: "dbo.Movies", newName: "Movie");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Movie", newName: "Movies");
            RenameTable(name: "dbo.MembershipType", newName: "MembershipTypes");
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
