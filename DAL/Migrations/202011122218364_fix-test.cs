namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixtest : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CompositionFranchises", name: "Composition_Id", newName: "CompositionId");
            RenameColumn(table: "dbo.CompositionFranchises", name: "Franchise_Id", newName: "FranchiseId");
            RenameIndex(table: "dbo.CompositionFranchises", name: "IX_Composition_Id", newName: "IX_CompositionId");
            RenameIndex(table: "dbo.CompositionFranchises", name: "IX_Franchise_Id", newName: "IX_FranchiseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CompositionFranchises", name: "IX_FranchiseId", newName: "IX_Franchise_Id");
            RenameIndex(table: "dbo.CompositionFranchises", name: "IX_CompositionId", newName: "IX_Composition_Id");
            RenameColumn(table: "dbo.CompositionFranchises", name: "FranchiseId", newName: "Franchise_Id");
            RenameColumn(table: "dbo.CompositionFranchises", name: "CompositionId", newName: "Composition_Id");
        }
    }
}
