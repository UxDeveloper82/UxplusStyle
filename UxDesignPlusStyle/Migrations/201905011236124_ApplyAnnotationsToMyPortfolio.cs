namespace UxDesignPlusStyle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToMyPortfolio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyPortfolios", "Type", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyPortfolios", "Type", c => c.String());
        }
    }
}
