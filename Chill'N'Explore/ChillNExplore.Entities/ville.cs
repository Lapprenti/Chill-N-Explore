//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChillNExplore.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ville
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ville()
        {
            this.joueurs = new HashSet<joueur>();
            this.lieux = new HashSet<lieu>();
        }
    
        public string idville { get; set; }
        public string nom { get; set; }
        public string pos { get; set; }
        public Nullable<float> rayon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<joueur> joueurs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lieu> lieux { get; set; }
    }
}
