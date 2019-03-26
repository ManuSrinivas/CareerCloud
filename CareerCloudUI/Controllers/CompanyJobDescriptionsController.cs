using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloudUI.Controllers
{
    public class CompanyJobDescriptionsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobDescriptions
        public ActionResult Index(Guid? Id)
        {
			if (Id != null)
			{
				var companyJobDescriptions = db.CompanyJobDescriptions.Where(c => c.Job == Id);
				return View(companyJobDescriptions);
			}
			else
			{
				var companyJobDescriptions = db.CompanyJobDescriptions.Include(c => c.CompanyJob);
				return View(companyJobDescriptions.ToList());
			}
        }

        // GET: CompanyJobDescriptions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescriptions/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id");
            return View();
        }

        // POST: CompanyJobDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,JobName,JobDescriptions")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobDescriptionPoco.Id = Guid.NewGuid();
                db.CompanyJobDescriptions.Add(companyJobDescriptionPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescriptions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,JobName,JobDescriptions")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobDescriptionPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobDescriptionPoco.Job);
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescriptions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescriptions.Find(id);
            db.CompanyJobDescriptions.Remove(companyJobDescriptionPoco);
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
