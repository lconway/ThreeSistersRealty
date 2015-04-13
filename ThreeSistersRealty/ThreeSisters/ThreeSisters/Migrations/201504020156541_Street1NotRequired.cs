namespace ThreeSisters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Street1NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Listings", "Street1", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "Street1", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
