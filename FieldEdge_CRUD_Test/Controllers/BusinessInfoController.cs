using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FieldEdge_CRUD_Test.Models;

namespace FieldEdge_CRUD_Test.Controllers
{
    public class BusinessInfoController : Controller
    {

        private FieldEdgeTestEntities db = new FieldEdgeTestEntities();

        // GET: BusinessInfo
        public async Task<ActionResult> Index()
        {
            return View(await db.BusinessInfoes.ToListAsync());
        }

        // GET: BusinessInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessInfo businessInfo = await db.BusinessInfoes.FindAsync(id);
            if (businessInfo == null)
            {
                return HttpNotFound();
            }
            return View(businessInfo);
        }

        // GET: BusinessInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Orginization,Business,Date_Recieved,Amount,Email,Phone_Number,Address")] BusinessInfo businessInfo)
        {
            if (ModelState.IsValid)
            {
                db.BusinessInfoes.Add(businessInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(businessInfo);
        }

        // GET: BusinessInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessInfo businessInfo = await db.BusinessInfoes.FindAsync(id);
            if (businessInfo == null)
            {
                return HttpNotFound();
            }
            return View(businessInfo);
        }

        // POST: BusinessInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Orginization,Business,Date_Recieved,Amount,Email,Phone_Number,Address")] BusinessInfo businessInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(businessInfo);
        }

        // GET: BusinessInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessInfo businessInfo = await db.BusinessInfoes.FindAsync(id);
            if (businessInfo == null)
            {
                return HttpNotFound();
            }
            return View(businessInfo);
        }

        // POST: BusinessInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BusinessInfo businessInfo = await db.BusinessInfoes.FindAsync(id);
            db.BusinessInfoes.Remove(businessInfo);
            await db.SaveChangesAsync();
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
