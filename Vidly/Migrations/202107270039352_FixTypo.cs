namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class FixTypo : DbMigration
  {
    public override void Up()
    {
      Sql(@"UPDATE MembershipType SET Name = 'Monthly' WHERE ID = 2;");
    }

    public override void Down()
    {
    }
  }
}
