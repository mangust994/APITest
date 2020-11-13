namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minifix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int());
            DropColumn("dbo.Comments", "ClientProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ClientProfileId", c => c.Int());
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
