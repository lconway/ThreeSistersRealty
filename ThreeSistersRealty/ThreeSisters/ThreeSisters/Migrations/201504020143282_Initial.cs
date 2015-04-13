namespace ThreeSisters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingID = c.Int(nullable: false, identity: true),
                        MSL = c.String(nullable: false),
                        Street1 = c.String(nullable: false, maxLength: 30),
                        Street2 = c.String(maxLength: 20),
                        City = c.String(maxLength: 20),
                        State = c.String(maxLength: 2),
                        Zipcode = c.String(maxLength: 10),
                        Neighborhood = c.String(maxLength: 20),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateListed = c.DateTime(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        Bathrooms = c.Int(nullable: false),
                        GarageSize = c.String(),
                        SquareFeet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LotSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.ListingID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Photos", new[] { "ListingId" });
            DropForeignKey("dbo.Photos", "ListingId", "dbo.Listings");
            DropTable("dbo.Photos");
            DropTable("dbo.Listings");
        }
    }
}
