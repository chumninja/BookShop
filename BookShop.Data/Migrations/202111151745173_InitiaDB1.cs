namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiaDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "MetaKeyWord", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreateDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "UpdateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "Status");
            DropColumn("dbo.PostCategories", "UpdateDate");
            DropColumn("dbo.PostCategories", "UpdateBy");
            DropColumn("dbo.PostCategories", "CreateDate");
            DropColumn("dbo.PostCategories", "CreateBy");
            DropColumn("dbo.PostCategories", "MetaKeyWord");
            DropColumn("dbo.PostCategories", "MetaDescription");
        }
    }
}
