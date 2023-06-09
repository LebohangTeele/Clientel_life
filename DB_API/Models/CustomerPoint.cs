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
    
    public partial class CustomerPoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPoint()
        {
            this.Credits = new HashSet<Credit>();
        }
    
        public int ProPointsID { get; set; }
        public Nullable<int> ProID { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<System.DateTime> RedeemedDate { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<int> CusID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
