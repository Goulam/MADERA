//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madera.ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class MDR_Etat_Paiement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MDR_Etat_Paiement()
        {
            this.MDR_Paiement = new HashSet<MDR_Paiement>();
        }
    
        public int EPai_Index { get; set; }
        public string EPai_Etat { get; set; }
        public System.DateTime EPai_Date { get; set; }
        public Nullable<int> EPai_Actif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDR_Paiement> MDR_Paiement { get; set; }
    }
}
