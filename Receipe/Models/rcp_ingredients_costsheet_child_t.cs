//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Receipe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class rcp_ingredients_costsheet_child_t
    {
        public int id { get; set; }
        [DisplayName("Cost Sheet No")]
        public int rcp_ingredients_costsheet_id { get; set; }
        [DisplayName("Ingredients")]
        public int ingredients_id { get; set; }
        [DisplayName("Measurement")]
        public int rct_ingredients_measurement_unit { get; set; }
        [DisplayName("Standard Cost")]
        public decimal rec_standard_cost { get; set; }
        [DisplayName("Standard Deviation")]
        public int rec_standard_deviation_percentage { get; set; }
    }
}
