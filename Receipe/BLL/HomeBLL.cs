using Receipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Receipe.BLL
{
    public class HomeBLL
    {
        private HMS_LIVEEntities db = new HMS_LIVEEntities();
        

        public List<ingredie> getIngredieList()
        {

            List<ingredie> ingredieList = new List<ingredie>() {
                new ingredie(){ id=1, ingredieName="Rice"},
                new ingredie(){ id=2, ingredieName="Pasta"},
                new ingredie(){ id=3, ingredieName="French Fries"},
                new ingredie(){ id=4, ingredieName="Ice Cream"}
            };

            return ingredieList;
        }
        public List<unit> getUnitList()
        {

            List<unit> unitList = new List<unit>() {
                new unit(){ id=1, unitName="kg"},
                new unit(){ id=2, unitName="mg"},
                new unit(){ id=3, unitName="litter"},
                new unit(){ id=4, unitName="cm"}
            };

            return unitList;
        }
        public int get_ingredients_costsheet_id()
        {
            var costsheet_id = db.rcp_ingredients_costsheet_parent_t.OrderBy(x=>x.id).ToList().LastOrDefault().id;
            return costsheet_id;
        }

        public bool isIngredientInserted(DateTime fromdate ,DateTime todate, int ingredientId)
        {
            bool isTrue=false;
            DateTime FromDate = Convert.ToDateTime(fromdate);
            DateTime ToDate = Convert.ToDateTime(todate);
            
            int costsheetId;
            var costsheet = db.rcp_ingredients_costsheet_parent_t.Where(m => m.effective_from_date == FromDate || m.effective_to_date == ToDate).Select(x => x.id).ToList();

            int[] costSheetIdList = new int[costsheet.Count - 1]; 
            for (int i = 0; i < costsheet.Count - 1; i++)
            {
                int id = costsheet[i];
                costsheetId = db.rcp_ingredients_costsheet_child_t.Where(m => m.rcp_ingredients_costsheet_id == id && m.ingredients_id == ingredientId).OrderBy(x => x.ingredients_id).Select(m => m.id).FirstOrDefault();

                costSheetIdList[i]= costsheetId;
            }
            if(costSheetIdList.Length!=0)
            {
                isTrue = true;
            }
             return isTrue;
        }
        public List<rcp_ingredients_costsheet_child_t> get_data()
        {
            var costSheetList = db.rcp_ingredients_costsheet_child_t.OrderBy(x => x.id).ToList();
            return costSheetList;
        }
        public List<rcp_ingredients_costsheet_child_t> get_data_within_date_range(string fromdate,string todate)
        {
            DateTime FromDate = Convert.ToDateTime(fromdate);
            DateTime ToDate = Convert.ToDateTime(todate);
            var costsheet =  db.rcp_ingredients_costsheet_parent_t.Where(m => m.effective_from_date == FromDate && m.effective_to_date==ToDate).Select(x=>x.id).ToList();
            int costsheetId = costsheet[0];
            var costSheetList = db.rcp_ingredients_costsheet_child_t.Where(m=>m.rcp_ingredients_costsheet_id== costsheetId).OrderBy(x => x.id).ToList();

            return costSheetList;

        }
    }
}