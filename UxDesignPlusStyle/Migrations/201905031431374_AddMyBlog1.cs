namespace UxDesignPlusStyle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyBlog1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyBlogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        imageUrl = c.String(),
                        Author = c.String(),
                        DatePost = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyBlogs");
        }
    }
}
