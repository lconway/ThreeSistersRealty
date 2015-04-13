using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ThreeSisters.Models {
    public class Photo {
        public int PhotoId { get; set; }

        public int ListingId { get; set; }
        public string ImagePath { get; set; }
        public virtual Listing Listing { get; set; }
    }
}