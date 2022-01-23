namespace firstCodeAndHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "photo");
        }
    }
}
