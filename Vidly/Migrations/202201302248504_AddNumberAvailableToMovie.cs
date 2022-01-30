namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "NumberAvailable", c => c.Byte(nullable: false));

            Sql("UPDATE dbo.Movie SET NumberAvaiable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "NumberAvailable");
        }
    }
}
