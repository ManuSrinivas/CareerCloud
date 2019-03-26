using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloudUI.Controllers
{
    public class ApplicantEducationsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

		private ApplicantEducationLogic Logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));

        // GET: ApplicantEducations
        public ActionResult Index(Guid? Id)
        {
			if (Id != null)
			{
				var apEdu = Logic.GetAll().Where(a => a.Applicant == Id);
				//var applicantEducations = db.ApplicantEducations.Where(a => a.Applicant == Id);//.Include(a => a.ApplicantProfile);
				//return View(applicantEducations.ToList());
				return View(apEdu.ToList());
			}
			else
			{
				var applicantEducations = Logic.GetAll();//db.ApplicantEducations.Include(a => a.ApplicantProfile);
				return View(applicantEducations.ToList());
			}
      
        }

        // GET: ApplicantEducations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ApplicantEducationPoco applicantEducationPoco = Logic.Get(id.Value);//db.ApplicantEducations.Find(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducations/Create
        public ActionResult Create()
        {
			 ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency");
			//ViewBag.Applicant = new SelectList(Logic.GetAll(), "Id", "Currency");
            return View();
        }

        // POST: ApplicantEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantEducationPoco.Id = Guid.NewGuid();
				// db.ApplicantEducations.Add(applicantEducationPoco);
				// db.SaveChanges();
				ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[5];
				pocos[0] = applicantEducationPoco;
				Logic.Add(pocos);
                return RedirectToAction("Index");
            }

			ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantEducationPoco.Applicant);
			//ViewBag.Applicant = new SelectList(Logic.GetAll(), "Id", "Currency", applicantEducationPoco.Applicant);
			return View(applicantEducationPoco);
        }

        // GET: ApplicantEducations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ApplicantEducationPoco applicantEducationPoco = Logic.Get(id.Value);//db.ApplicantEducations.Find(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantEducationPoco.Applicant);
			//ViewBag.Applicant = new SelectList(Logic.GetAll(), "Id", "Currency", applicantEducationPoco.Applicant);
			return View(applicantEducationPoco);
        }

        // POST: ApplicantEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
				//db.Entry(applicantEducationPoco).State = EntityState.Modified;
				//db.SaveChanges();
				ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[2];
				pocos[0] = applicantEducationPoco;
				Logic.Update(pocos);
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantEducationPoco.Applicant);
			//ViewBag.Applicant = new SelectList(Logic.GetAll(), "Id", "Currency", applicantEducationPoco.Applicant);
			return View(applicantEducationPoco);
        }

        // GET: ApplicantEducations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ApplicantEducationPoco applicantEducationPoco = Logic.Get(id.Value);// db.ApplicantEducations.Find(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
			ApplicantEducationPoco applicantEducationPoco = Logic.Get(id);//db.ApplicantEducations.Find(id);
			//db.ApplicantEducations.Remove(applicantEducationPoco);
			//db.SaveChanges();
			ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[2];
			pocos[0] = applicantEducationPoco;
			Logic.Delete(pocos);
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
