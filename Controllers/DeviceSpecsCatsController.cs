using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class DeviceSpecsCatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeviceSpecsCats
        public ActionResult Index()
        {
            return View(db.DeviceSpecsCats.ToList());
        }

        // GET: DeviceSpecsCats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsCat deviceSpecsCat = db.DeviceSpecsCats.Find(id);
            if (deviceSpecsCat == null)
            {
                return HttpNotFound();
            }
            return View(deviceSpecsCat);
        }

        // GET: DeviceSpecsCats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceSpecsCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeviceSpecsCatId,DeviceSpecsCatName,DeviceSpecsCatDateCreated,DeviceSpecsCatCreatedBy,DeviceSpecsCatDateModified,DeviceSpecsCatModifiedBy")] DeviceSpecsCat deviceSpecsCat)
        {
            deviceSpecsCat.DeviceSpecsCatDateCreated    = DateTime.Now;
            deviceSpecsCat.DeviceSpecsCatDateModified   = DateTime.Now;
            deviceSpecsCat.DeviceSpecsCatCreatedBy      = User.Identity.Name;
            deviceSpecsCat.DeviceSpecsCatModifiedBy     = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.DeviceSpecsCats.Add(deviceSpecsCat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceSpecsCat);
        }

        // GET: DeviceSpecsCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsCat deviceSpecsCat = db.DeviceSpecsCats.Find(id);
            if (deviceSpecsCat == null)
            {
                return HttpNotFound();
            }
            return View(deviceSpecsCat);
        }

        // POST: DeviceSpecsCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeviceSpecsCatId,DeviceSpecsCatName,DeviceSpecsCatDateCreated,DeviceSpecsCatCreatedBy,DeviceSpecsCatDateModified,DeviceSpecsCatModifiedBy")] DeviceSpecsCat deviceSpecsCat)
        {
            
            if (ModelState.IsValid)
            {
                var a = db.DeviceSpecsCats.Where(x => x.DeviceSpecsCatId == deviceSpecsCat.DeviceSpecsCatId).FirstOrDefault();

                if (a != null)
                {
                    a.DeviceSpecsCatName        = deviceSpecsCat.DeviceSpecsCatName;
                    a.DeviceSpecsCatDateCreated = a.DeviceSpecsCatDateCreated;
                    a.DeviceSpecsCatCreatedBy   = a.DeviceSpecsCatCreatedBy;
                    a.DeviceSpecsCatDateModified = DateTime.Now;
                    a.DeviceSpecsCatModifiedBy  = User.Identity.Name;

                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(deviceSpecsCat);
        }

        // GET: DeviceSpecsCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsCat deviceSpecsCat = db.DeviceSpecsCats.Find(id);
            if (deviceSpecsCat == null)
            {
                return HttpNotFound();
            }
            return View(deviceSpecsCat);
        }

        // POST: DeviceSpecsCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceSpecsCat deviceSpecsCat = db.DeviceSpecsCats.Find(id);
            db.DeviceSpecsCats.Remove(deviceSpecsCat);
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
