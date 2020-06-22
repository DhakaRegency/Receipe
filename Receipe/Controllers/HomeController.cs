using Receipe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Receipe.Controllers
{
    public class HomeController : Controller
    {
        private HMS_LIVEEntities db = new HMS_LIVEEntities();
        public ActionResult Index()
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

            List<ingredie> ingredieList = new List<ingredie>() {
                new ingredie(){ id=1, ingredieName="Bill"},
                new ingredie(){ id=2, ingredieName="Steve"},
                new ingredie(){ id=3, ingredieName="Ram"},
                new ingredie(){ id=4, ingredieName="Moin"}
            };
            List<unit> unitList = new List<unit>() {
                new unit(){ id=1, unitName="kg"},
                new unit(){ id=2, unitName="mg"},
                new unit(){ id=3, unitName="litter"},
                new unit(){ id=4, unitName="cm"}
            };

            ViewBag.IngredieList = ingredieList;
            ViewBag.UnitList = unitList;

            ViewBag.userId = new SelectList(ingredieList, "id", "ingredieName");

            rcp_Viewmodel[0].ingredieList = ingredieList;
            rcp_Viewmodel[0].unitList = unitList;


            return View(rcp_Viewmodel);
        }


        [HttpPost]
        public ActionResult Index(List<rcp_viewmodel> _rcp_Viewmodel, List<FormCollection> form)
        {
            rcp_viewmodel rcp_Viewmodel = new rcp_viewmodel();

            List<ingredie> ingredieList = new List<ingredie>() {
                new ingredie(){ id=1, ingredieName="Rice"},
                new ingredie(){ id=2, ingredieName="Pasta"},
                new ingredie(){ id=3, ingredieName="French Fries"},
                new ingredie(){ id=4, ingredieName="Ice Cream"}
            };
            List<unit> unitList = new List<unit>() {
                new unit(){ id=1, unitName="kg"},
                new unit(){ id=2, unitName="mg"},
                new unit(){ id=3, unitName="litter"},
                new unit(){ id=4, unitName="cm"}
            };

            ViewBag.IngredieList = ingredieList;
            ViewBag.UnitList = unitList;

            rcp_Viewmodel.ingredieList = ingredieList;
            rcp_Viewmodel.unitList = unitList;

            char[] IngredieId =form[0]["ingredieList"].ToString().ToArray();
            char[] UnitID = form[1]["UnitList"].ToString().ToArray();


            
             
            for(int i=0;i<15;i++)
            {
                rcp_ingredients_costsheet_child_t rcp_Ingredients_Costsheet_Child_T = new rcp_ingredients_costsheet_child_t();
                rcp_Ingredients_Costsheet_Child_T.ingredients_id = IngredieId[i];
                rcp_Ingredients_Costsheet_Child_T.rct_ingredients_measurement_unit = UnitID[i];
                rcp_Ingredients_Costsheet_Child_T.rcp_ingredients_costsheet_id = 1;
                rcp_Ingredients_Costsheet_Child_T.rec_standard_cost = _rcp_Viewmodel[i].price;
                rcp_Ingredients_Costsheet_Child_T.rec_standard_deviation_percentage = _rcp_Viewmodel[i].elements;
                db.rcp_ingredients_costsheet_child_t.Add(rcp_Ingredients_Costsheet_Child_T);
                db.SaveChanges();
            }



            rcp_ingredients_costsheet_parent_t rcp_Ingredients_Costsheet_Parent_T = new rcp_ingredients_costsheet_parent_t();
            rcp_Ingredients_Costsheet_Parent_T.effective_from_date = _rcp_Viewmodel[0].fromDate;
            rcp_Ingredients_Costsheet_Parent_T.effective_to_date = _rcp_Viewmodel[0].toDate;

            db.rcp_ingredients_costsheet_parent_t.Add(rcp_Ingredients_Costsheet_Parent_T);
            db.SaveChanges();

            return RedirectToAction("Index", "IngredientsCostsheet");

        }


    }
}