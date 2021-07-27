namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class AddMovieProperties : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
      AddColumn("dbo.Movie", "DateAdded", c => c.DateTime(nullable: false));
      AddColumn("dbo.Movie", "NumberInStock", c => c.Int(nullable: false));

      Sql("INSERT INTO dbo.Movie (Name, ReleaseDate, DateAdded, NumberInStock) VALUES ('Shrek', '2001-01-02', '2015-05-01', 34)");
      Sql("INSERT INTO dbo.Movie (Name, ReleaseDate, DateAdded, NumberInStock) VALUES ('Terminator', '1984-10-31', '2018-09-12', 4)");

    }

    public override void Down()
    {
      DropColumn("dbo.Movie", "NumberInStock");
      DropColumn("dbo.Movie", "DateAdded");
      DropColumn("dbo.Movie", "ReleaseDate");
    }
  }
}
