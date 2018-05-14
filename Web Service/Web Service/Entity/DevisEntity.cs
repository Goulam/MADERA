using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Service.Entity
{
    public class DevisEntity
    {
        public int Dev_Index { get; set; }
        public decimal Dev_Prix { get; set; }
        public Nullable<int> Dev_Actif { get; set; }
    }
}
