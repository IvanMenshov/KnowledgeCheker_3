using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowledgeCheker_3.Models;

namespace KnowledgeCheker_3.Controllers
{
    public class RegisterToCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterToCompanies
        public ActionResult Index()
        {
            return View(db.RegisterToCompanies.ToList());
        }

        // GET: RegisterToCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterToCompany registerToCompany = db.RegisterToCompanies.Find(id);
            if (registerToCompany == null)
            {
                return HttpNotFound();
            }
            return View(registerToCompany);
        }

        // GET: RegisterToCompanies/Create
        public ActionResult Create()
        {
            var viewModel = new RegisterToCompany();

            if (Request.IsAuthenticated)
            {
                viewModel.Email = User.Identity.Name;
                viewModel.Data = DateTime.Today;
            }

            return View();
        }

        // POST: RegisterToCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,UserName,Data,Comment")] RegisterToCompany registerToCompany)
        {
            if (ModelState.IsValid)
            {
                db.RegisterToCompanies.Add(registerToCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerToCompany);
        }

        // GET: RegisterToCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterToCompany registerToCompany = db.RegisterToCompanies.Find(id);
            if (registerToCompany == null)
            {
                return HttpNotFound();
            }
            return View(registerToCompany);
        }

        // POST: RegisterToCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,UserName,Data,Comment")] RegisterToCompany registerToCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerToCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerToCompany);
        }

        // GET: RegisterToCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterToCompany registerToCompany = db.RegisterToCompanies.Find(id);
            if (registerToCompany == null)
            {
                return HttpNotFound();
            }
            return View(registerToCompany);
        }

        // POST: RegisterToCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterToCompany registerToCompany = db.RegisterToCompanies.Find(id);
            db.RegisterToCompanies.Remove(registerToCompany);
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
