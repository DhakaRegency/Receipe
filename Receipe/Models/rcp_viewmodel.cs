using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Receipe.Models


{
    public class rcp_viewmodel
    {
        [DisplayName("Ingredients")]
        public List<rcp_ingredients_list_t> ingredieList { get; set; }

        [DisplayName("Unit")]
        public List<pos_measurement_t> unitList { get; set; }
        [DisplayName("Price")]
        public decimal price { get; set; }
        [DisplayName("Standard Deviation")]
        public int deviation { get; set; }

        [DisplayName("From date")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime fromDate { get; set; }

        [DisplayName("To Date")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime toDate { get; set; }

    }
}