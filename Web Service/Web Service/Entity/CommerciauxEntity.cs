using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.Entity
{
    public class CommerciauxEntity
    {
        public int Com_Index { get; set; }
        public string Com_Nom { get; set; }
        public string Com_Identifiant { get; set; }
        public string Com_Mdp { get; set; }
        public Nullable<int> Com_Actif { get; set; }
    }
}
