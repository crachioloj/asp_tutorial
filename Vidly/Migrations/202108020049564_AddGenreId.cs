namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movie", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Movie", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movie", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Movie", name: "GenreId", newName: "Genre_Id");
        }
    }
}
