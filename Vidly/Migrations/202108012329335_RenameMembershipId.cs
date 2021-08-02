namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class RenameMembershipId : DbMigration
  {
    public override void Up()
    {
      RenameColumn("dbo.MembershipType", "ID", "Id");
    }

    public override void Down()
    {
      RenameColumn("dbo.MembershipType", "Id", "ID");
    }
  }
}
