using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORCA2.Models;
using Microsoft.AspNet.Identity;
namespace ORCA2.Controllers
{
    public class PersonController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserLists
        public async System.Threading.Tasks.Task<ActionResult> Index(string stringName)
        {
            var user = from s in db.UserLists
                       select s;
            if (!string.IsNullOrEmpty(stringName))
            {
                user = user.Where(s => s.EmailAddress.Contains(stringName));
            }
            return View(await user.ToListAsync());
        }

        // GET: UserLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // GET: UserLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ExpertID,FirstName,LastName,PhoneNumber,EmailAddress")] Person userList)
        {
            if (ModelState.IsValid)
            {
                db.UserLists.Add(userList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userList);
        }

        // GET: UserLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }

            return View(userList);
        }

        // POST: UserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmailAddress,FirstName,LastName,PhoneNumber")] Person userList)
        {

            if (ModelState.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                //var temp = (from d in db.Users where d.Email == userList.EmailAddress);
                db.Entry(userList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { stringName = currentUser.Email }); 
            }
            return View(userList);
        }

        // GET: UserLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person userList = db.UserLists.Find(id);
            db.UserLists.Remove(userList);
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
