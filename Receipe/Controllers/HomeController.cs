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
            rcp_viewmodel rcp_Viewmodel = new rcp_viewmodel();

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

            rcp_Viewmodel.ingredieList = ingredieList;
            rcp_Viewmodel.unitList = unitList;


            return View(rcp_Viewmodel);
        }

        
        [HttpPost]
        public ActionResult Index(rcp_viewmodel _rcp_Viewmodel,FormCollection form)
        {
            rcp_viewmodel rcp_Viewmodel = new rcp_viewmodel();

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

            rcp_Viewmodel.ingredieList = ingredieList;
            rcp_Viewmodel.unitList = unitList;

            int IngredieId =Convert.ToInt32( form["IngredieList"].ToString());
            int UnitID = Convert.ToInt32(form["UnitList"].ToString());

            rcp_ingredients_costsheet_child_t rcp_Ingredients_Costsheet_Child_T = new rcp_ingredients_costsheet_child_t();
            rcp_Ingredients_Costsheet_Child_T.ingredients_id = IngredieId;
            rcp_Ingredients_Costsheet_Child_T.rct_ingredients_measurement_unit = UnitID;
            rcp_Ingredients_Costsheet_Child_T.rcp_ingredients_costsheet_id = 1;
            rcp_Ingredients_Costsheet_Child_T.rec_standard_cost = _rcp_Viewmodel.price;
            rcp_Ingredients_Costsheet_Child_T.rec_standard_deviation_percentage = _rcp_Viewmodel.elements;

             
            
            db.rcp_ingredients_costsheet_child_t.Add(rcp_Ingredients_Costsheet_Child_T);
            db.SaveChanges();
               
            
            return RedirectToAction("Index","IngredientsCostsheet");

        }

        
    }
}