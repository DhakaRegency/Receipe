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
    
    public partial class rcp_recipe_parent_t
    {
        public int id { get; set; }
        public string recipe_name { get; set; }
        public int wastage_percentage { get; set; }
        public int yeild_percentage { get; set; }
        public int portion { get; set; }
        public short is_active { get; set; }
    }
}