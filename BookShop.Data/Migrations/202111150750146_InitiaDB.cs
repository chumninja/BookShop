namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiaDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameMenu = c.String(nullable: false, maxLength: 250),
                        Link = c.String(maxLength: 8000, unicode: false),
                        DisplayOrder = c.Int(),
                        Target = c.String(),
                        GroupID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        CustomerName = c.String(maxLength: 250),
                        CustomerAddress = c.String(maxLength: 250),
                        CustomerMail = c.String(maxLength: 250),
                        CustomerPhone = c.String(maxLength: 250),
                        CustomerMessage = c.String(maxLength: 250),
                        CreateDate = c.DateTime(),
                        PaymentMethod = c.String(maxLength: 250),
                        PaymentStatus = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(maxLength: 250, unicode: false),
                        CategoryID = c.Int(nullable: false),
                        MoreImage = c.String(storeType: "xml"),
                        Promotion = c.Decimal(precision: 18, scale: 2),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Content = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        HomeFlag = c.Boolean(),
                        Images = c.String(maxLength: 8000, unicode: false),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyWord = c.String(maxLength: 256),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Images = c.String(maxLength: 8000, unicode: false),
                        HomeFlag = c.Boolean(),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyWord = c.String(maxLength: 256),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NamePage = c.String(nullable: false, maxLength: 250),
                        Content = c.String(maxLength: 4000),
                        Alias = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NamePost = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 4000),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Images = c.String(maxLength: 8000, unicode: false),
                        HomeFlag = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NamePost = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(maxLength: 250),
                        CategoryPostID = c.Int(nullable: false),
                        MoreImage = c.String(storeType: "xml"),
                        Content = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        HomeFlag = c.Boolean(),
                        Images = c.String(maxLength: 8000, unicode: false),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyWord = c.String(maxLength: 256),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.CategoryPostID, cascadeDelete: true)
                .Index(t => t.CategoryPostID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        NameTag = c.String(nullable: false, maxLength: 250, unicode: false),
                        Type = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Sildes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 4000),
                        Images = c.String(maxLength: 8000, unicode: false),
                        Url = c.String(maxLength: 8000, unicode: false),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Department = c.String(maxLength: 250),
                        Skype = c.String(maxLength: 250),
                        Facebook = c.String(maxLength: 250),
                        Mobile = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        valueString = c.String(),
                        vauleInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(),
                        IPAdress = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryPostID", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroup");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "CategoryPostID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropTable("dbo.VisitorStatices");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Sildes");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroup");
            DropTable("dbo.Footers");
        }
    }
}
