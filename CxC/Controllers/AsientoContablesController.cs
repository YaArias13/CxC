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
    public class AsientoContablesController : Controller
    {
        private Cuentas_por_CobrarEntities db = new Cuentas_por_CobrarEntities();

        // GET: AsientoContables
        public ActionResult Index()
        {
            return View(db.AsientoContables.ToList());
        }

        // GET: AsientoContables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.AsientoContables.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientoContables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsientoID,Descripcion,Id,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                db.AsientoContables.Add(asientoContable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asientoContable);
        }

        // GET: AsientoContables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.AsientoContables.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // POST: AsientoContables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsientoID,Descripcion,Id,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientoContable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.AsientoContables.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // POST: AsientoContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsientoContable asientoContable = db.AsientoContables.Find(id);
            db.AsientoContables.Remove(asientoContable);
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
