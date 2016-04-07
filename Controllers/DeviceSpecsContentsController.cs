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
    public class DeviceSpecsContentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeviceSpecsContents
        public ActionResult Index()
        {
            var deviceSpecsContents = db.DeviceSpecsContents.Include(d => d.Devices).Include(d => d.DeviceSpecsCat);
            return View(deviceSpecsContents.ToList());
        }

        // GET: DeviceSpecsContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsContent deviceSpecsContent = db.DeviceSpecsContents.Find(id);
            if (deviceSpecsContent == null)
            {
                return HttpNotFound();
            }
            return View(deviceSpecsContent);
        }

        // GET: DeviceSpecsContents/Create
        public ActionResult Create()
        {
            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "DeviceName");
            ViewBag.DeviceSpecsCatId = new SelectList(db.DeviceSpecsCats, "DeviceSpecsCatId", "DeviceSpecsCatName");
            return View();
        }

        // POST: DeviceSpecsContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeviceSpecsContentId,DeviceSpecsCatId,DeviceId,DeviceSpecsContentVal,DeviceSpecsContentDateCreated,DeviceSpecsContentCreatedBy,DeviceSpecsContentDateModified,DeviceSpecsContentModifiedBy")] DeviceSpecsContent deviceSpecsContent)
        {
            deviceSpecsContent.DeviceSpecsContentDateCreated    = DateTime.Now;
            deviceSpecsContent.DeviceSpecsContentDateModified   = DateTime.Now;
            deviceSpecsContent.DeviceSpecsContentCreatedBy      = User.Identity.Name;
            deviceSpecsContent.DeviceSpecsContentModifiedBy     = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.DeviceSpecsContents.Add(deviceSpecsContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "DeviceName", deviceSpecsContent.DeviceId);
            ViewBag.DeviceSpecsCatId = new SelectList(db.DeviceSpecsCats, "DeviceSpecsCatId", "DeviceSpecsCatName", deviceSpecsContent.DeviceSpecsCatId);
            return View(deviceSpecsContent);
        }

        // GET: DeviceSpecsContents/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsContent deviceSpecsContent = db.DeviceSpecsContents.Find(id);
            if (deviceSpecsContent == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "DeviceName", deviceSpecsContent.DeviceId);
            ViewBag.DeviceSpecsCatId = new SelectList(db.DeviceSpecsCats, "DeviceSpecsCatId", "DeviceSpecsCatName", deviceSpecsContent.DeviceSpecsCatId);
            return View(deviceSpecsContent);
        }

        // POST: DeviceSpecsContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeviceSpecsContentId,DeviceSpecsCatId,DeviceId,DeviceSpecsContentVal,DeviceSpecsContentDateCreated,DeviceSpecsContentCreatedBy,DeviceSpecsContentDateModified,DeviceSpecsContentModifiedBy")] DeviceSpecsContent deviceSpecsContent)
        {
            
            if (ModelState.IsValid)
            {

                var a = db.DeviceSpecsContents.Where(x => x.DeviceSpecsContentId == deviceSpecsContent.DeviceSpecsContentId).FirstOrDefault();

                if (a != null)
                {
                    a.DeviceSpecsCatId              = deviceSpecsContent.DeviceSpecsCatId;
                    a.DeviceId                      = deviceSpecsContent.DeviceId;
                    a.DeviceSpecsContentVal         = deviceSpecsContent.DeviceSpecsContentVal;
                    a.DeviceSpecsContentDateCreated = a.DeviceSpecsContentDateCreated;
                    a.DeviceSpecsContentCreatedBy   = a.DeviceSpecsContentCreatedBy;
                    a.DeviceSpecsContentDateModified = DateTime.Now;
                    a.DeviceSpecsContentModifiedBy  = User.Identity.Name;

                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "DeviceId", "DeviceName", deviceSpecsContent.DeviceId);
            ViewBag.DeviceSpecsCatId = new SelectList(db.DeviceSpecsCats, "DeviceSpecsCatId", "DeviceSpecsCatName", deviceSpecsContent.DeviceSpecsCatId);
            return View(deviceSpecsContent);
        }

        // GET: DeviceSpecsContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceSpecsContent deviceSpecsContent = db.DeviceSpecsContents.Find(id);
            if (deviceSpecsContent == null)
            {
                return HttpNotFound();
            }
            return View(deviceSpecsContent);
        }

        // POST: DeviceSpecsContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceSpecsContent deviceSpecsContent = db.DeviceSpecsContents.Find(id);
            db.DeviceSpecsContents.Remove(deviceSpecsContent);
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
