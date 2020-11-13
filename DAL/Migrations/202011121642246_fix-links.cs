namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixlinks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FranchiseCompositions", "Franchise_Id", "dbo.Franchises");
            DropForeignKey("dbo.FranchiseCompositions", "Composition_Id", "dbo.Compositions");
            DropForeignKey("dbo.GenreCompositions", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreCompositions", "Composition_Id", "dbo.Compositions");
            DropIndex("dbo.FranchiseCompositions", new[] { "Franchise_Id" });
            DropIndex("dbo.FranchiseCompositions", new[] { "Composition_Id" });
            DropIndex("dbo.GenreCompositions", new[] { "Genre_Id" });
            DropIndex("dbo.GenreCompositions", new[] { "Composition_Id" });
            CreateTable(
                "dbo.CompositionFranchises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Composition_Id = c.Int(),
                        Franchise_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compositions", t => t.Composition_Id)
                .ForeignKey("dbo.Franchises", t => t.Franchise_Id)
                .Index(t => t.Composition_Id)
                .Index(t => t.Franchise_Id);
            
            CreateTable(
                "dbo.CompositionGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Composition_Id = c.Int(),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compositions", t => t.Composition_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Composition_Id)
                .Index(t => t.Genre_Id);
            
            DropTable("dbo.FranchiseCompositions");
            DropTable("dbo.GenreCompositions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreCompositions",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Composition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Composition_Id });
            
            CreateTable(
                "dbo.FranchiseCompositions",
                c => new
                    {
                        Franchise_Id = c.Int(nullable: false),
                        Composition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Franchise_Id, t.Composition_Id });
            
            DropForeignKey("dbo.CompositionGenres", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.CompositionGenres", "Composition_Id", "dbo.Compositions");
            DropForeignKey("dbo.CompositionFranchises", "Franchise_Id", "dbo.Franchises");
            DropForeignKey("dbo.CompositionFranchises", "Composition_Id", "dbo.Compositions");
            DropIndex("dbo.CompositionGenres", new[] { "Genre_Id" });
            DropIndex("dbo.CompositionGenres", new[] { "Composition_Id" });
            DropIndex("dbo.CompositionFranchises", new[] { "Franchise_Id" });
            DropIndex("dbo.CompositionFranchises", new[] { "Composition_Id" });
            DropTable("dbo.CompositionGenres");
            DropTable("dbo.CompositionFranchises");
            CreateIndex("dbo.GenreCompositions", "Composition_Id");
            CreateIndex("dbo.GenreCompositions", "Genre_Id");
            CreateIndex("dbo.FranchiseCompositions", "Composition_Id");
            CreateIndex("dbo.FranchiseCompositions", "Franchise_Id");
            AddForeignKey("dbo.GenreCompositions", "Composition_Id", "dbo.Compositions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreCompositions", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FranchiseCompositions", "Composition_Id", "dbo.Compositions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FranchiseCompositions", "Franchise_Id", "dbo.Franchises", "Id", cascadeDelete: true);
        }
    }
}
