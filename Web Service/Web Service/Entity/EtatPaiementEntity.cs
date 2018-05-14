using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class EtatPaiementEntity
    {
        public int EPai_Index { get; set; }
        public string EPai_Etat { get; set; }
        public System.DateTime EPai_Date { get; set; }
        public Nullable<int> EPai_Actif { get; set; }
    }
}
