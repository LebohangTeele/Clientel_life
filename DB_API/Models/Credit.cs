//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Credit
    {
        public int CreID { get; set; }
        public Nullable<int> ProPointsID { get; set; }
        public string Credit1 { get; set; }
    
        public virtual CustomerPoint CustomerPoint { get; set; }
    }
}
