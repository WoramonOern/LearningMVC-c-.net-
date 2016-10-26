namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ( Name, Genre_Id, ReleasedDate, DateAdded, NumberInStock) VALUES ( 'Hangover', 1, '2008-10-05', '2016-05-18', 20)");
            Sql("INSERT INTO Movies ( Name, Genre_Id, ReleasedDate, DateAdded, NumberInStock) VALUES ( 'Die Hard', 2, '2010-05-07', '2016-06-03', 12)");
            Sql("INSERT INTO Movies ( Name, Genre_Id, ReleasedDate, DateAdded, NumberInStock) VALUES ( 'The Terminator', 2, '2012-11-08', '2016-07-15', 15)");
            Sql("INSERT INTO Movies ( Name, Genre_Id, ReleasedDate, DateAdded, NumberInStock) VALUES ( 'Toy Story', 3, '2011-08-25', '2016-08-21', 8)");
            Sql("INSERT INTO Movies ( Name, Genre_Id, ReleasedDate, DateAdded, NumberInStock) VALUES ( 'Titanic', 4, '2014-02-14', '2016-02-14', 5)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Movies WHERE Id = 5");
            Sql("DELETE FROM Movies WHERE Id = 4");
            Sql("DELETE FROM Movies WHERE Id = 3");
            Sql("DELETE FROM Movies WHERE Id = 2");
            Sql("DELETE FROM Movies WHERE Id = 1");
        }
    }
}
