using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class ComposantsEntity
    {
        public int Comp_Index { get; set; }
        public string Comp_Nom { get; set; }
        public string Comp_Type { get; set; }
        public string Comp_Couleur { get; set; }
        public Nullable<int> Comp_Actif { get; set; }
    }
}
