using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSisters.Models;

namespace ThreeSisters.Controllers
{
    public class ListingController : Controller
    {
        private SistersDbContext db = new SistersDbContext();

        //
        // GET: /Listing/

        public ActionResult Index() {
            return View(db.Listings.ToList());
        }

        public ActionResult SearchListings(string mslNumber = "", string city = "",
            string state = "", string zipcode = "", string bedrooms = "",
            string bathrooms = "", string sqFt = "") {

                var listings = from l in db.Listings
                               select l;

                if (!String.IsNullOrEmpty(mslNumber)) {
                    listings = listings.Where(l => l.MSL.Equals(mslNumber));
                }
                if (!String.IsNullOrEmpty(city)) {
                    listings = listings.Where(l => l.City.Equals(city));
                }
                if (!String.IsNullOrEmpty(state)) {
                    listings = listings.Where(l => l.State.Equals(state));
                }
                if (!String.IsNullOrEmpty(zipcode)) {
                    listings = listings.Where(l => l.Zipcode.Equals(zipcode));
                }
                if (!String.IsNullOrEmpty(bedrooms)) {
                    int bedrms = Convert.ToInt32(bedrooms);
                    listings = listings.Where(l => l.Bedrooms == bedrms);
                }
                if (!String.IsNullOrEmpty(bathrooms)) {
                    decimal bathrms = Convert.ToDecimal(bathrooms);
                    listings = listings.Where(l => l.Bathrooms == bathrms);
                }
                if (!String.IsNullOrEmpty(sqFt)) {
                    decimal squareFeet = Convert.ToDecimal(sqFt);
                    listings = listings.Where(l => l.SquareFeet >= squareFeet);
                }

                return View("Index", listings);
        }

        //
        // GET: /Listing/Details/5

        public ActionResult Details(int id = 0) {
            Listing listing = db.Listings.Find(id);
            if (listing == null) {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // GET: /Listing/MoreImages/5

        public ActionResult MoreImages(int id = 0) {
            Listing listing = db.Listings.Find(id);
            if (listing == null) {
                return HttpNotFound();
            }
            ViewBag.ListingId = id;
            ViewBag.Path = "~/Images/House Images/";
            return View(listing.Photos.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}