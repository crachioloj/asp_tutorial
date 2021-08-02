namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerMembershipID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "MembershipType_ID", "dbo.MembershipType");
            DropIndex("dbo.Customer", new[] { "MembershipType_ID" });
            RenameColumn(table: "dbo.Customer", name: "MembershipType_ID", newName: "MembershipTypeId");
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "MembershipTypeId");
            AddForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MembershipTypeId", "dbo.MembershipType");
            DropIndex("dbo.Customer", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customer", "MembershipTypeId", c => c.Int());
            RenameColumn(table: "dbo.Customer", name: "MembershipTypeId", newName: "MembershipType_ID");
            CreateIndex("dbo.Customer", "MembershipType_ID");
            AddForeignKey("dbo.Customer", "MembershipType_ID", "dbo.MembershipType", "ID");
        }
    }
}
