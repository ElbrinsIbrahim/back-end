namespace firstCodeAndHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catalogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        desc = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        bref = c.String(),
                        desc = c.String(),
                        date = c.DateTime(nullable: false),
                        photo = c.String(),
                        user_id = c.Int(),
                        cat_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.catalogs", t => t.cat_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.cat_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        email = c.String(),
                        password = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "user_id", "dbo.users");
            DropForeignKey("dbo.news", "cat_id", "dbo.catalogs");
            DropIndex("dbo.news", new[] { "cat_id" });
            DropIndex("dbo.news", new[] { "user_id" });
            DropTable("dbo.users");
            DropTable("dbo.news");
            DropTable("dbo.catalogs");
        }
    }
}
