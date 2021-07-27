namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class AddMembershipTypeValues : DbMigration
  {
    public override void Up()
    {
      Sql(@"UPDATE MembershipType SET Name = 'Pay as You Go' WHERE ID = 1;");
      Sql(@"UPDATE MembershipType SET Name = 'Montly' WHERE ID = 2;");
      Sql(@"UPDATE MembershipType SET Name = 'Seasonally' WHERE ID = 3;");
      Sql(@"UPDATE MembershipType SET Name = 'Yearly' WHERE ID = 4;");
    }

    public override void Down()
    {
    }
  }
}
