using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Receipe.Models


{
    public  class ingredie
    {

      public  int id { get; set; }
      public string ingredieName { get; set; }

    }
    public class unit
    {

        public int id { get; set; }
        public string unitName { get; set; }

    }
    public class rcp_viewmodel
    {
        public List<ingredie> ingredieList { get; set; }
        public List<unit> unitList { get; set; }

        public decimal price { get; set; }

        public int elements { get; set; }

    }
}