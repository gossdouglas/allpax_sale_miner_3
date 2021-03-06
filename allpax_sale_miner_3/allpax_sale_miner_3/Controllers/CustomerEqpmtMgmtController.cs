﻿using System;
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
    public class CustomerEqpmtMgmtController : Controller
    {
        private allpax_sale_minerEntities db = new allpax_sale_minerEntities();

        // GET: CustomerEqpmtMgmt
        public ActionResult Index()
        {
            var tbl_customer_eqpmt = db.tbl_customer_eqpmt.Include(t => t.tbl_customer);
            return View(tbl_customer_eqpmt.ToList());
        }

        // GET: CustomerEqpmtMgmt/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Create
        public ActionResult Create()
        {
            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "name");
            return View();
        }

        // POST: CustomerEqpmtMgmt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerCode,machineID,eqpmtType,id")] tbl_customer_eqpmt tbl_customer_eqpmt)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customer_eqpmt.Add(tbl_customer_eqpmt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "name", tbl_customer_eqpmt.customerCode);
            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "name", tbl_customer_eqpmt.customerCode);
            return View(tbl_customer_eqpmt);
        }

        // POST: CustomerEqpmtMgmt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerCode,machineID,eqpmtType,id")] tbl_customer_eqpmt tbl_customer_eqpmt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customer_eqpmt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerCode = new SelectList(db.tbl_customer, "customerCode", "name", tbl_customer_eqpmt.customerCode);
            return View(tbl_customer_eqpmt);
        }

        // GET: CustomerEqpmtMgmt/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            if (tbl_customer_eqpmt == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer_eqpmt);
        }

        // POST: CustomerEqpmtMgmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_customer_eqpmt tbl_customer_eqpmt = db.tbl_customer_eqpmt.Find(id);
            db.tbl_customer_eqpmt.Remove(tbl_customer_eqpmt);
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
