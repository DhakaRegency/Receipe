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
    
    public partial class rcp_recipe_child_t
    {
        public int id { get; set; }
        public int recipe_parent_id { get; set; }
        public int ingredients_id { get; set; }
        public int measurement_unit { get; set; }
        public int sub_recipe_id { get; set; }
        public short is_sub_reipe { get; set; }
    }
}