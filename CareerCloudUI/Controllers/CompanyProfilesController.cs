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
    public class CompanyProfilesController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyProfiles
        public ActionResult Index()
        {
            return View(db.CompanyProfilePocoes.ToList());
        }

        // GET: CompanyProfiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfilePocoes.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                db.CompanyProfilePocoes.Add(companyProfilePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfilePocoes.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfilePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfilePocoes.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyProfilePoco companyProfilePoco = db.CompanyProfilePocoes.Find(id);
            db.CompanyProfilePocoes.Remove(companyProfilePoco);
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
