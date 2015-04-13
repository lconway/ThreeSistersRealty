using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;

namespace ThreeSisters.Models {
    public class SistersDbContext : DbContext {
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }

    public class Listing {
        public int ListingID { get; set; }

        [Required]
        public string MSL { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string Street1 { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Street2 { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be the 2 character abreviation")]
        public string State { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string Zipcode { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Neighborhood { get; set; }

        [DataType(DataType.Currency)]
        public decimal SalesPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateListed { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public string GarageSize { get; set; }

        public decimal SquareFeet { get; set; }

        public decimal LotSize { get; set; }

        public String Description { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public virtual List<Photo> Photos { get; set; }
    }
}