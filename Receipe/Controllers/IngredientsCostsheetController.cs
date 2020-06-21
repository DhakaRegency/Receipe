using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Receipe.Models;

namespace Receipe.Controllers
{
    public class IngredientsCostsheetController : Controller
    {
        private HMS_LIVEEntities db = new HMS_LIVEEntities();

        // GET: IngredientsCostsheet
        public ActionResult Index()
        {
            return View(db.rcp_ingredients_costsheet_child_t.ToList());
        }

        // GET: IngredientsCostsheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t = db.rcp_ingredients_costsheet_child_t.Find(id);
            if (rcp_ingredients_costsheet_child_t == null)
            {
                return HttpNotFound();
            }
            return View(rcp_ingredients_costsheet_child_t);
        }

        // GET: IngredientsCostsheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientsCostsheet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rcp_ingredients_costsheet_id,ingredients_id,rct_ingredients_measurement_unit,rec_standard_cost,rec_standard_deviation_percentage")] rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t)
        {
            if (ModelState.IsValid)
            {
                db.rcp_ingredients_costsheet_child_t.Add(rcp_ingredients_costsheet_child_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rcp_ingredients_costsheet_child_t);
        }

        // GET: IngredientsCostsheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t = db.rcp_ingredients_costsheet_child_t.Find(id);
            if (rcp_ingredients_costsheet_child_t == null)
            {
                return HttpNotFound();
            }
            return View(rcp_ingredients_costsheet_child_t);
        }

        // POST: IngredientsCostsheet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rcp_ingredients_costsheet_id,ingredients_id,rct_ingredients_measurement_unit,rec_standard_cost,rec_standard_deviation_percentage")] rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rcp_ingredients_costsheet_child_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rcp_ingredients_costsheet_child_t);
        }

        // GET: IngredientsCostsheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t = db.rcp_ingredients_costsheet_child_t.Find(id);
            if (rcp_ingredients_costsheet_child_t == null)
            {
                return HttpNotFound();
            }
            return View(rcp_ingredients_costsheet_child_t);
        }

        // POST: IngredientsCostsheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rcp_ingredients_costsheet_child_t rcp_ingredients_costsheet_child_t = db.rcp_ingredients_costsheet_child_t.Find(id);
            db.rcp_ingredients_costsheet_child_t.Remove(rcp_ingredients_costsheet_child_t);
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
