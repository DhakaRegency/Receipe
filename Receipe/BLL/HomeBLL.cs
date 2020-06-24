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

        public List<rcp_viewmodel> getViewModelList()
        {
            try
            {

               List<rcp_viewmodel> rcp_Viewmodel = new List<rcp_viewmodel>{
               new rcp_viewmodel { price = 0, deviation = 0 ,fromDate=DateTime.Now,toDate=DateTime.Now},
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
               new rcp_viewmodel { price = 0, deviation = 0 },
           };
                return rcp_Viewmodel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<rcp_ingredients_list_t> getIngredieList()
        {

            List<rcp_ingredients_list_t> ingredieList = new List<rcp_ingredients_list_t>();
            ingredieList = db.rcp_ingredients_list_t.OrderBy(m => m.id).ToList();

            return ingredieList;
        }
        public List<pos_measurement_t> getUnitList()
        {

            List<pos_measurement_t> unitList = new List<pos_measurement_t>();
            unitList = db.pos_measurement_t.OrderBy(m => m.code).ToList();

            return unitList;
        }
        public int get_ingredients_costsheet_id()
        {
            try
            {
                var costsheet_id = db.rcp_ingredients_costsheet_parent_t.OrderBy(x => x.id).ToList().LastOrDefault().id;
                return costsheet_id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool isIngredientInserted(DateTime fromdate, DateTime todate, int ingredientId)
        {
            try
            {

                bool isTrue = false;
                DateTime FromDate = Convert.ToDateTime(fromdate);
                DateTime ToDate = Convert.ToDateTime(todate);

                int costsheetId;
                var costsheet = db.rcp_ingredients_costsheet_parent_t.Where(m => m.effective_from_date == FromDate || m.effective_to_date == ToDate).Select(x => x.id).ToList();

                int[] costSheetIdList = new int[costsheet.Count - 1];
                for (int i = 0; i < costsheet.Count - 1; i++)
                {
                    int id = costsheet[i];
                    costsheetId = db.rcp_ingredients_costsheet_child_t.Where(m => m.rcp_ingredients_costsheet_id == id && m.ingredients_id == ingredientId).OrderBy(x => x.ingredients_id).Select(m => m.id).FirstOrDefault();

                    costSheetIdList[i] = costsheetId;
                }
                if (costSheetIdList.Length != 0)
                {
                    isTrue = true;
                }
                return isTrue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<rcp_ingredients_costsheet_child_t> get_data()
        {
            try
            {

                var costSheetList = db.rcp_ingredients_costsheet_child_t.OrderBy(x => x.id).ToList();
                return costSheetList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<rcp_ingredients_costsheet_child_t> get_data_within_date_range(string fromdate, string todate)
        {
            try
            {

                DateTime FromDate = Convert.ToDateTime(fromdate);
                DateTime ToDate = Convert.ToDateTime(todate);
                var costsheet = db.rcp_ingredients_costsheet_parent_t.Where(m => m.effective_from_date >= FromDate && m.effective_to_date <= ToDate).Select(x => x.id).ToList();
                int costsheetId = 0;
                if (costsheet.Count != 0)
                {
                    costsheetId = costsheet[0];
                }

                var costSheetList = db.rcp_ingredients_costsheet_child_t.Where(m => m.rcp_ingredients_costsheet_id == costsheetId).OrderBy(x => x.id).ToList();

                return costSheetList;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}