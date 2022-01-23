namespace firstCodeAndHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.users", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.users", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "email", c => c.String());
            AlterColumn("dbo.users", "name", c => c.String(nullable: false));
        }
    }
}
