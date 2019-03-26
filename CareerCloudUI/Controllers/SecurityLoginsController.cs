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
    public class SecurityLoginsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLogins
        public ActionResult Index()
        {
            return View(db.SecurityLogins.ToList());
        }

        // GET: SecurityLogins/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // GET: SecurityLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Password,Created,PasswordUpdate,AgreementAccepted,IsLocked,IsInactive,EmailAddress,PhoneNumber,FullName,ForceChangePassword,PrefferredLanguage")] SecurityLoginPoco securityLoginPoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginPoco.Id = Guid.NewGuid();
                db.SecurityLogins.Add(securityLoginPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(securityLoginPoco);
        }

        // GET: SecurityLogins/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // POST: SecurityLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Password,Created,PasswordUpdate,AgreementAccepted,IsLocked,IsInactive,EmailAddress,PhoneNumber,FullName,ForceChangePassword,PrefferredLanguage")] SecurityLoginPoco securityLoginPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityLoginPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(securityLoginPoco);
        }

        // GET: SecurityLogins/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // POST: SecurityLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginPoco securityLoginPoco = db.SecurityLogins.Find(id);
            db.SecurityLogins.Remove(securityLoginPoco);
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
