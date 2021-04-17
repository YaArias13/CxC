using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CxC.Models;

namespace CxC.Controllers
{
    public class TipDocsController : Controller
    {
        private Cuentas_por_CobrarEntities db = new Cuentas_por_CobrarEntities();

        // GET: TipDocs
        public ActionResult Index()
        {
            return View(db.TipDocs.ToList());
        }

        // GET: TipDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDoc tipDoc = db.TipDocs.Find(id);
            if (tipDoc == null)
            {
                return HttpNotFound();
            }
            return View(tipDoc);
        }

        // GET: TipDocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipDocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,CuentaContable,Estado")] TipDoc tipDoc)
        {
            if (ModelState.IsValid)
            {
                db.TipDocs.Add(tipDoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipDoc);
        }

        // GET: TipDocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDoc tipDoc = db.TipDocs.Find(id);
            if (tipDoc == null)
            {
                return HttpNotFound();
            }
            return View(tipDoc);
        }

        // POST: TipDocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,CuentaContable,Estado")] TipDoc tipDoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipDoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipDoc);
        }

        // GET: TipDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDoc tipDoc = db.TipDocs.Find(id);
            if (tipDoc == null)
            {
                return HttpNotFound();
            }
            return View(tipDoc);
        }

        // POST: TipDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipDoc tipDoc = db.TipDocs.Find(id);
            db.TipDocs.Remove(tipDoc);
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
