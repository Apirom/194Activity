using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication29;

namespace WebApplication29.Controllers
{
    public class MonksController : Controller
    {
        private MonkContainer db = new MonkContainer();

        // GET: Monks //หาFname
        public ActionResult Index(string searchString)
        {
            var search = from m in db.Monks select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Fname.Contains(searchString));
            }
            return View(search);
        } //หาID
        public ActionResult Index2(string searchString)
        {
            var search = from m in db.Monks select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Cid.Contains(searchString));
            }
            return View(search);
        }
        
        // GET: Monks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monk monk = db.Monks.Find(id);
            if (monk == null)
            {
                return HttpNotFound();
            }
            return View(monk);
        }

        // GET: Monks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cid,Religion,Blood,SWno,Fname,Lname,Bdate,Age,Pno,Htown,Tribe,Bparent,FFname,FLname,Fage,Ftribe,MFname,MLname,Mage,Mtribe,Sib_num,Sib_ord,Sib_men,Sib_women")] Monk monk)
        {
            if (ModelState.IsValid)
            {
                db.Monks.Add(monk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monk);
        }

        // GET: Monks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monk monk = db.Monks.Find(id);
            if (monk == null)
            {
                return HttpNotFound();
            }
            return View(monk);
        }

        // POST: Monks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cid,Religion,Blood,SWno,Fname,Lname,Bdate,Age,Pno,Htown,Tribe,Bparent,FFname,FLname,Fage,Ftribe,MFname,MLname,Mage,Mtribe,Sib_num,Sib_ord,Sib_men,Sib_women")] Monk monk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monk);
        }

        // GET: Monks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monk monk = db.Monks.Find(id);
            if (monk == null)
            {
                return HttpNotFound();
            }
            return View(monk);
        }

        // POST: Monks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monk monk = db.Monks.Find(id);
            db.Monks.Remove(monk);
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
