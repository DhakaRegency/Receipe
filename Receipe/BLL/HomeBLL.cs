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
        public int get_ingredients_costsheet_id()
        {
            var costsheet_id = db.rcp_ingredients_costsheet_parent_t.OrderBy(x=>x.id).ToList().LastOrDefault().id;
            return costsheet_id;
        }
    }
}