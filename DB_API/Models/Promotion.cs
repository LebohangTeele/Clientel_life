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
    
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            this.CustomerPoints = new HashSet<CustomerPoint>();
        }
    
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string Prodiscription { get; set; }
        public Nullable<System.DateTime> ProStartDate { get; set; }
        public Nullable<System.DateTime> ProEndDate { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> PointValue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPoint> CustomerPoints { get; set; }
    }
}
