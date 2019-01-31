using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterneraStore.Models;
using InterneraStore.ViewModels;

namespace InterneraStore.Controllers
{
    public class SellersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Sellers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        public ActionResult Create()
        {
            ViewBag.Companies = db.Companies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SellerViewModel sellerViewModel)
        {
            if (ModelState.IsValid)
            {
                sellerViewModel.Seller.Company = db.Companies.Find(sellerViewModel.CompanyId);
                db.Sellers.Add(sellerViewModel.Seller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellerViewModel);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Companies = db.Companies;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sellerViewModel = new SellerViewModel();
            Seller seller = db.Sellers.Find(id);
            sellerViewModel.Seller = seller;

            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(sellerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SellerViewModel sellerViewModel)
        {
            if (ModelState.IsValid)
            {
                Seller seller = EditSeller(sellerViewModel);

                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellerViewModel);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seller seller = db.Sellers.Find(id);
            db.Sellers.Remove(seller);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Seller EditSeller(SellerViewModel sellerViewModel)
        {
            Seller seller = db.Sellers.Find(sellerViewModel.Seller.Id);
            seller.Company = db.Companies.Find(sellerViewModel.CompanyId);
            seller.Name = sellerViewModel.Seller.Name;
            return seller;
        }
    }
}
