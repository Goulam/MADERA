using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class PaiementEntity
    {
        public int Pai_Index { get; set; }
        public int Pai_Type { get; set; }
        public int Pai_Etat { get; set; }
        public Nullable<int> Pai_Actif { get; set; }
    }
}
