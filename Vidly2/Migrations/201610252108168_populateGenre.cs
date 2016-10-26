namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genre WHERE Id = 4");
            Sql("DELETE FROM Genre WHERE Id = 3");
            Sql("DELETE FROM Genre WHERE Id = 2");
            Sql("DELETE FROM Genre WHERE Id = 1");
        }
    }
}
