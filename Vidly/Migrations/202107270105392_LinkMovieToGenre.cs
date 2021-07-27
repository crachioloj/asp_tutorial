namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class LinkMovieToGenre : DbMigration
  {
    public override void Up()
    {
      Sql("UPDATE dbo.Movie SET Genre_Id = 1 WHERE Id = 1;");
      Sql("UPDATE dbo.Movie SET Genre_Id = 3 WHERE Id = 2;");
    }

    public override void Down()
    {
    }
  }
}
