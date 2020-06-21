using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Ingredients")]
        public List<ingredie> ingredieList { get; set; }
        [DisplayName("Unit")]
        public List<unit> unitList { get; set; }
        [DisplayName("Price")]

        public decimal price { get; set; }
        [DisplayName("Elements")]
        public int elements { get; set; }

    }
}