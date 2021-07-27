namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class PopulateDateOfBirth : DbMigration
  {
    public override void Up()
    {
      Sql("UPDATE dbo.Customer SET DateOfBirth = '1979/12/06' WHERE Id = 1;");
    }

    public override void Down()
    {
    }
  }
}
