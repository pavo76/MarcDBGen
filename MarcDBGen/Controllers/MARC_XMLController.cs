using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarcDBGen.Models;

namespace MarcDBGen.Controllers
{
    public class MARC_XMLController : Controller
    {
        private MARC db = new MARC();

        // GET: MARC_XML
        public ActionResult Index()
        {
            var list = db.MARC_XML.ToList();
            ViewBag.sql = Parser.Parse(list);
            return View(db.MARC_XML.ToList());
        }

        // GET: MARC_XML/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARC_XML mARC_XML = db.MARC_XML.Find(id);
            if (mARC_XML == null)
            {
                return HttpNotFound();
            }
            return View(mARC_XML);
        }

        // GET: MARC_XML/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MARC_XML/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Broj_Knjige,XML,Datum_preuzimanja")] MARC_XML mARC_XML)
        {
            if (ModelState.IsValid)
            {
                db.MARC_XML.Add(mARC_XML);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mARC_XML);
        }

        // GET: MARC_XML/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARC_XML mARC_XML = db.MARC_XML.Find(id);
            if (mARC_XML == null)
            {
                return HttpNotFound();
            }
            return View(mARC_XML);
        }

        // POST: MARC_XML/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Broj_Knjige,XML,Datum_preuzimanja")] MARC_XML mARC_XML)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARC_XML).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mARC_XML);
        }

        // GET: MARC_XML/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARC_XML mARC_XML = db.MARC_XML.Find(id);
            if (mARC_XML == null)
            {
                return HttpNotFound();
            }
            return View(mARC_XML);
        }

        // POST: MARC_XML/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MARC_XML mARC_XML = db.MARC_XML.Find(id);
            db.MARC_XML.Remove(mARC_XML);
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
