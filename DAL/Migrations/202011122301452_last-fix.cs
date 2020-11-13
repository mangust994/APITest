namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CompositionGenres", name: "Composition_Id", newName: "CompositionId");
            RenameColumn(table: "dbo.CompositionGenres", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.CompositionGenres", name: "IX_Composition_Id", newName: "IX_CompositionId");
            RenameIndex(table: "dbo.CompositionGenres", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CompositionGenres", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.CompositionGenres", name: "IX_CompositionId", newName: "IX_Composition_Id");
            RenameColumn(table: "dbo.CompositionGenres", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.CompositionGenres", name: "CompositionId", newName: "Composition_Id");
        }
    }
}
