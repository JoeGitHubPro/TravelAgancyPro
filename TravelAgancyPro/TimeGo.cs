//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAgancyPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeGo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeGo()
        {
            this.Travelers = new HashSet<Traveler>();
        }
    
        public int TimeGoID { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> DestinationGoID { get; set; }
    
        public virtual DestinationGo DestinationGo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Traveler> Travelers { get; set; }
    }
}
