namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcomment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "ComMark", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "ComMark", c => c.String());
        }
    }
}
