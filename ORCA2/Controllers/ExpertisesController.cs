using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORCA2.Models;

namespace ORCA2.Controllers
{
    public class ExpertisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expertises
        public ActionResult Index(string department, string searchString)
        {
            var DepLst = new List<string>();

            var GenreQry = from d in db.Expertises
                           orderby d.Department
                           select d.Department;

            DepLst.AddRange(GenreQry.Distinct());
            ViewBag.department = new SelectList(DepLst);

            var expertiseList = from m in db.Expertises
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                expertiseList = expertiseList.Where(s => s.Field.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(department))
            {
                expertiseList = expertiseList.Where(x => x.Department == department);
            }

            return View(expertiseList);
        }

        // GET: Expertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertise expertise = db.Expertises.Find(id);
            if (expertise == null)
            {
                return HttpNotFound();
            }
            return View(expertise);
        }

        // GET: Expertises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpertiseID,ContactEmail,Department,Field,Validated")] Expertise expertise)
        {
            if (ModelState.IsValid)
            {
                expertise.LinkedEmail = User.Identity.Name;
                expertise.Validated = false;
                db.Expertises.Add(expertise);
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }

            return View(expertise);
        }

        // GET: Expertises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertise expertise = db.Expertises.Find(id);
            if (expertise == null)
            {
                return HttpNotFound();
            }
            return View(expertise);
        }

        // POST: Expertises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpertiseID, Field, Department, LinkedEmail, ContactEmail, Validated")] Expertise expertise)
        {
            if (ModelState.IsValid)
            {
                //expertise.Validated = true;
                db.Entry(expertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expertise);
        }

        // GET: Expertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertise expertise = db.Expertises.Find(id);
            if (expertise == null)
            {
                return HttpNotFound();
            }
            return View(expertise);
        }

        // POST: Expertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expertise expertise = db.Expertises.Find(id);
            db.Expertises.Remove(expertise);
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
