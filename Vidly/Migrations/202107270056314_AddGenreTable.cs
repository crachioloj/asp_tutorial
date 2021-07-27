namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Genre_Id");
            AddForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Genre_Id", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "Genre_Id" });
            DropColumn("dbo.Movie", "Genre_Id");
            DropTable("dbo.Genre");
        }
    }
}
