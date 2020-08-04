using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxOfficeASP.Context;
using BoxOfficeASP.Models;

namespace BoxOfficeASP.Controllers
{
    public class SeanceController : Controller
    {
        public ActionResult Index()
        {
            return View(mDataBase.Seances.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = mDataBase.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeanceId,StartTime,MovieTitle")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                mDataBase.Seances.Add(seance);
                mDataBase.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seance);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = mDataBase.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeanceId,StartTime,MovieTitle")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                mDataBase.Entry(seance).State = EntityState.Modified;
                mDataBase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seance);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = mDataBase.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seance seance = mDataBase.Seances.Find(id);
            mDataBase.Seances.Remove(seance);
            mDataBase.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mDataBase.Dispose();
            }
            base.Dispose(disposing);
        }

        private BoxOfficeContext mDataBase = new BoxOfficeContext();
    }
}
