namespace ThreeSisters.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ThreeSisters.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ThreeSisters.Models.ThreeSistersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ThreeSisters.Models.ThreeSistersDbContext context) 
        {
            var listings = new List<Listing> {
                new Listing {
                    MSL = "B294827",
                    Street1 = "2912 NW Celilo Ln",
                    Street2 = "",
                    City = "Bend",
                    State = "OR",
                    Zipcode = "97701",
                    Neighborhood = "Summit West",
                    SalesPrice = 1099500.00m,
                    DateListed = DateTime.Parse("2014-08-01"),
                    Bedrooms = 4,
                    Bathrooms = 4,
                    GarageSize = "3 car garage",
                    SquareFeet = 3977,
                    LotSize = 0.33m,
                    Description = "Set on a beautifully landscaped corner lot, the exquisite craftsmanship of this home is a show stopper! 3 large bedrooms up 4th bdrm/office down has attached bath. Huge bonus room with full wet bar, fireplace & home theatre wiring. Spacious chef's dream kitchen. Multiple outdoor living spaces. Extensive use of travertine, slab granite, quarter-sawn oak and Montana Mossy Rock. Oversized 3 car garage. Potential galore for the unfinished space downstairs! Call today for your private viewing."
                },

                new Listing {
                    MSL = "783408",
                    Street1 = "1517 NW Mt. Washington Dr",
                    Street2 = "",
                    City = "Bend",
                    State = "OR",
                    Zipcode = "97701",
                    Neighborhood = "Northwest Crossing",
                    SalesPrice = 476500.00m,
                    DateListed = DateTime.Parse("2015-02-15"),
                    Bedrooms = 3,
                    Bathrooms = 2,
                    GarageSize = "2 car garage",
                    SquareFeet = 1435,
                    LotSize = 0.03m,
                    Description = "New construction"
                },

                new Listing {
                    MSL = "5566443",
                    Street1 = "1517 NW Mt. Washington Dr",
                    Street2 = "",
                    City = "Bend",
                    State = "OR",
                    Zipcode = "97701",
                    Neighborhood = "Northwest Crossing",
                    SalesPrice = 476500.00m,
                    DateListed = DateTime.Parse("2015-02-15"),
                    Bedrooms = 3,
                    Bathrooms = 2,
                    GarageSize = "2 car garage",
                    SquareFeet = 1435,
                    LotSize = 0.03m,
                    Description = "New construction"
                },

                new Listing {
                    MSL = "BL3845",
                    Street1 = "65440 NW 76th St",
                    Street2 = "",
                    City = "Bend",
                    State = "OR",
                    Zipcode = "97701",
                    Neighborhood = "",
                    SalesPrice = 619000.00m,
                    DateListed = DateTime.Parse("2015-01-08"),
                    Bedrooms = 3,
                    Bathrooms = 4,
                    GarageSize = "2 car garage",
                    SquareFeet = 2714,
                    LotSize = 2.39m,
                    Description = "Spectacular in every way! Enjoy this impeccably kept custom built home that offers 2,714 sf of luxurious living w/ an open floor plan and sumptuous interior appointments. Located on a spacious 2.3 acre lot that provides extreme privacy. The moment you walk through the door this home makes you feel welcome. As you explore notice the many gorgeous finishes including the kitchen you have always dreamed of, breath taking high vaulted ceilings in living room area with a ledger stone fireplace."
                }
            };

            listings.ForEach(l => context.Listings.AddOrUpdate(p => p.MSL, l));
            context.SaveChanges();
        }
    }
}
