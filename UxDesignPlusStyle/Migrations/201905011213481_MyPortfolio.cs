namespace UxDesignPlusStyle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPortfolio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyPortfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        imageUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyPortfolios");
        }
    }
}
