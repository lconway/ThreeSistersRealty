using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeSisters.Models;

namespace ThreeSisters.Controllers
{
    public class AdminController : Controller
    {
        private SistersDbContext db = new SistersDbContext();


        //
        // GET: /Admin
        [Authorize]
        public ActionResult Index() {
            return View(db.Listings.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Listing listing, HttpPostedFileBase image)
        {
            if (ModelState.IsValid) {
                if (image != null) {
                    listing.ImageMimeType = image.ContentType;
                    listing.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(listing.ImageData, 0, image.ContentLength);

                }

                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        //
        // GET: /Admin/Images/5

        public ActionResult Images(int id = 0) {
            Listing listing = db.Listings.Find(id);
            if (listing == null) {
                return HttpNotFound();
            }
            ViewBag.ListingId = id;
            ViewBag.Path = "~/Images/House Images/";
            return View(listing.Photos.ToList());
        }

        //
        // POST: /Admin/Images/5

        [HttpPost]
        public ActionResult Images(int listingId, Photo photo, HttpPostedFileBase image) {
            if (ModelState.IsValid) {
                if (image != null) {
                    if (photo == null) {
                        photo = new Photo();
                        photo.ListingId = listingId;
                    }
                    photo.ImagePath = image.FileName;                  
                }

                db.Entry(photo).State = EntityState.Modified;
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Images");
            }
            return View(photo);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0) {
            Listing listing = db.Listings.Find(id);
            if (listing == null) {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Listing listing, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null) {
                    listing.ImageMimeType = image.ContentType;
                    listing.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(listing.ImageData, 0, 
                        image.ContentLength);
                }

                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        //
        // /Admin/GetImage/5
        public FileContentResult GetImage(int listingId) {
            Listing listing = db.Listings.Find(listingId);
            if (listing != null)
                return File(listing.ImageData, listing.ImageMimeType);
            else
                return null;
        }

        //
        // GET: /Admin/DeleteImage/5/2

        public ActionResult DeleteImage(int id = 0, int listingId = 0) {
            Photo photo = db.Photos.Find(id);
            if (photo == null) {
                return HttpNotFound();
            }
            db.Photos.Remove(photo);
            db.SaveChanges();
            //return RedirectToAction("Images");
            return RedirectToAction("Images", new { id = listingId });
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0) {
            Listing listing = db.Listings.Find(id);
            if (listing == null) {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}