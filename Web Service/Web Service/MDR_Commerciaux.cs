//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class MDR_Commerciaux
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MDR_Commerciaux()
        {
            this.MDR_Devis = new HashSet<MDR_Devis>();
        }
    
        public int Com_Index { get; set; }
        public string Com_Nom { get; set; }
        public string Com_Identifiant { get; set; }
        public string Com_Mdp { get; set; }
        public Nullable<int> Com_Actif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDR_Devis> MDR_Devis { get; set; }
    }
}
