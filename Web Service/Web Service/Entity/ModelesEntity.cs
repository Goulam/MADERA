using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Service.Entity
{
    public class ModelesEntity
    {
        public int Model_Index { get; set; }
        public string Model_Nom { get; set; }
        public Nullable<int> Model_Actif { get; set; }
    }
}
