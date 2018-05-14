using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class ModulesEntity
    {
        public int Mod_Index { get; set; }
        public string Mod_Nom { get; set; }
        public decimal Mod_Prix { get; set; }
        public Nullable<System.DateTime> Mod_Date { get; set; }
        public Nullable<int> Mod_Actif { get; set; }
    }
}
