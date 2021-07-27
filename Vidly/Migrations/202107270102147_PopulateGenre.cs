namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class PopulateGenre : DbMigration
  {
    public override void Up()
    {
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Comedy');");
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Horror');");
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Action');");
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Drama');");
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Romance');");
      Sql("INSERT INTO dbo.Genre (Name) VALUES ('Garbage');");
    }

    public override void Down()
    {
    }
  }
}
