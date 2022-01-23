namespace firstCodeAndHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.users", "address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "address", c => c.String());
        }
    }
}
