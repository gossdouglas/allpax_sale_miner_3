using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_sale_miner_3.Models;

namespace allpax_sale_miner_3.Controllers
{
    public class CustomerMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerMgmt
        public ActionResult Index()
        {
            return View(db.tbl_customer.ToList());
        }

        // GET: CustomerMgmt/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // GET: CustomerMgmt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerCode,name,address,city,state,zipCode,id")] tbl_customer tbl_customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customer.Add(tbl_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_customer);
        }

        // GET: CustomerMgmt/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // POST: CustomerMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerCode,name,address,city,state,zipCode,id")] tbl_customer tbl_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_customer);
        }

        // GET: CustomerMgmt/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // POST: CustomerMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            db.tbl_customer.Remove(tbl_customer);
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
    }
}
