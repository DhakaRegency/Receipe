using Receipe.BLL;
using Receipe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Receipe.Controllers
{
    public class HomeController : Controller
    {
        private HMS_LIVEEntities db = new HMS_LIVEEntities();
        private HomeBLL HomeBll = new HomeBLL();
        static List<rcp_ingredients_costsheet_child_t> _rcp_ingredients_costsheet_child_t = new List<rcp_ingredients_costsheet_child_t>();
        public ActionResult Add()
        {
            List<rcp_viewmodel> rcp_Viewmodel = new List<rcp_viewmodel>{
               new rcp_viewmodel { price = 0, elements = 0 ,fromDate=DateTime.Now,toDate=DateTime.Now},
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
               new rcp_viewmodel { price = 0, elements = 0 },
           };


            ViewBag.IngredieList = HomeBll.getIngredieList();
            ViewBag.UnitList = HomeBll.getUnitList();

            ViewBag.userId = new SelectList(HomeBll.getIngredieList(), "id", "ingredieName");

            rcp_Viewmodel[0].ingredieList = HomeBll.getIngredieList();
            rcp_Viewmodel[0].unitList = HomeBll.getUnitList();


            return View(rcp_Viewmodel);
        }


        [HttpPost]
        public ActionResult Add(List<rcp_viewmodel> _rcp_Viewmodel, List<FormCollection> form)
        {
            rcp_viewmodel rcp_Viewmodel = new rcp_viewmodel();

            ViewBag.IngredieList = HomeBll.getIngredieList();
            ViewBag.UnitList = HomeBll.getUnitList();

            rcp_Viewmodel.ingredieList = HomeBll.getIngredieList();
            rcp_Viewmodel.unitList = HomeBll.getUnitList();


            string[] IngredieId = form[0]["ingredieList"].ToString().Split(',');
            string[] UnitID = form[1]["UnitList"].ToString().Split(',');

            rcp_ingredients_costsheet_parent_t rcp_Ingredients_Costsheet_Parent_T = new rcp_ingredients_costsheet_parent_t();
            rcp_Ingredients_Costsheet_Parent_T.effective_from_date = _rcp_Viewmodel[0].fromDate;
            rcp_Ingredients_Costsheet_Parent_T.effective_to_date = _rcp_Viewmodel[0].toDate;

            db.rcp_ingredients_costsheet_parent_t.Add(rcp_Ingredients_Costsheet_Parent_T);
            db.SaveChanges();

            int costsheet_id = HomeBll.get_ingredients_costsheet_id();
            for (int i = 0; i < 4; i++)
            {
                if (!(HomeBll.isIngredientInserted(_rcp_Viewmodel[0].fromDate, _rcp_Viewmodel[0].toDate, Convert.ToInt32(IngredieId[i]))))
                    {
                    rcp_ingredients_costsheet_child_t rcp_Ingredients_Costsheet_Child_T = new rcp_ingredients_costsheet_child_t();
                    rcp_Ingredients_Costsheet_Child_T.ingredients_id = Convert.ToInt32(IngredieId[i]);
                    rcp_Ingredients_Costsheet_Child_T.rct_ingredients_measurement_unit = Convert.ToInt32(UnitID[i]);
                    rcp_Ingredients_Costsheet_Child_T.rcp_ingredients_costsheet_id = costsheet_id;
                    rcp_Ingredients_Costsheet_Child_T.rec_standard_cost = _rcp_Viewmodel[i].price;
                    rcp_Ingredients_Costsheet_Child_T.rec_standard_deviation_percentage = _rcp_Viewmodel[i].elements;
                    db.rcp_ingredients_costsheet_child_t.Add(rcp_Ingredients_Costsheet_Child_T);
                    db.SaveChanges();
                }
                 
            }
            return RedirectToAction("Index", "IngredientsCostsheet");
        }


        public ActionResult Update()
        {

            ViewBag.IngredieList = HomeBll.getIngredieList();
            ViewBag.UnitList = HomeBll.getUnitList();

            return View(_rcp_ingredients_costsheet_child_t);
        }

        [HttpPost]
        public ActionResult Update(List<rcp_ingredients_costsheet_child_t> rcp_Ingredients_Costsheet_Child_Ts)
        {

            ViewBag.IngredieList = HomeBll.getIngredieList();
            ViewBag.UnitList = HomeBll.getUnitList();
            foreach (var item in rcp_Ingredients_Costsheet_Child_Ts)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "IngredientsCostsheet");
        }


        public ActionResult getCostSheet(FormCollection form)
        {
            ViewBag.IngredieList = HomeBll.getIngredieList();
            ViewBag.UnitList = HomeBll.getUnitList();

            string fromdate = form[0].ToString();
            string todate = form[1].ToString();

            _rcp_ingredients_costsheet_child_t = HomeBll.get_data_within_date_range(fromdate, todate);
            return RedirectToAction("Update", "Home", _rcp_ingredients_costsheet_child_t);
        }
    }
}