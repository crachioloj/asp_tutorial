namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeGenreRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "Genre_Id" });
            AlterColumn("dbo.Movie", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movie", "Genre_Id");
            AddForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "Genre_Id" });
            AlterColumn("dbo.Movie", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Genre_Id");
            AddForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre", "Id");
        }
    }
}
