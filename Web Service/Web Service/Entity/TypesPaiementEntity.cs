using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class TypesPaiementEntity
    {
        public int TPai_Index { get; set; }
        public string TPai_Nom { get; set; }
        public Nullable<int> TPai_Actif { get; set; }
    }
}
