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
    public class PurchasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index()
        {
            List<Purchase> purchases = db.Purchases.ToList();
            return View(purchases);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        
        public ActionResult Create()
        {
            ViewBag.Customers = db.Customers;
            ViewBag.Sellers = db.Sellers;
            ViewBag.Products = db.Products;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,ProductId,CustomerId,SellerId")] PurchaseViewModel purchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = GetPurchase(purchaseViewModel);
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseViewModel);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Customers = db.Customers;
            ViewBag.Sellers = db.Sellers;
            ViewBag.Products = db.Products;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var purchaseViewModel = new PurchaseViewModel();
            Purchase purchase = db.Purchases.Find(id);
            purchaseViewModel.Purchase = purchase;
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchaseViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseViewModel purchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = EditPurchase(purchaseViewModel);

                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseViewModel);
        }
        

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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

        private Purchase GetPurchase(PurchaseViewModel purchaseViewModel)
        {
            return new Purchase
            {
                Customer = db.Customers.Find(purchaseViewModel.CustomerId),
                Product = db.Products.Find(purchaseViewModel.ProductId),
                Seller = db.Sellers.Find(purchaseViewModel.SellerId),
                Quantity = purchaseViewModel.Quantity
            };
        }
        private Purchase EditPurchase(PurchaseViewModel purchaseViewModel)
        {
            Purchase purchase = db.Purchases.Find(purchaseViewModel.Purchase.Id);
            purchase.Product = db.Products.Find(purchaseViewModel.ProductId);
            purchase.Seller = db.Sellers.Find(purchaseViewModel.SellerId);
            purchase.Customer = db.Customers.Find(purchaseViewModel.CustomerId);
            purchase.Quantity = purchaseViewModel.Quantity;
            return purchase;
        }   
    }
}
