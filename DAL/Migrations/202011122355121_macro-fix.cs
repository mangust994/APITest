namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class macrofix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "UserId");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "UserId" });
            AlterColumn("dbo.Comments", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Comments", "UserId", c => c.Int());
            CreateIndex("dbo.Comments", "User_Id");
        }
    }
}
