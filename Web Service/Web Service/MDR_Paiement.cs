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
    
    public partial class MDR_Paiement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MDR_Paiement()
        {
            this.MDR_Etat_Paiement = new HashSet<MDR_Etat_Paiement>();
            this.MDR_Types_Paiement = new HashSet<MDR_Types_Paiement>();
            this.MDR_Commandes = new HashSet<MDR_Commandes>();
        }
    
        public int Pai_Index { get; set; }
        public int Pai_Type { get; set; }
        public int Pai_Etat { get; set; }
        public Nullable<int> Pai_Actif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDR_Etat_Paiement> MDR_Etat_Paiement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDR_Types_Paiement> MDR_Types_Paiement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDR_Commandes> MDR_Commandes { get; set; }
    }
}
