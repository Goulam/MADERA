using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Model;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.BLL
{
    public class CommerciauxController : CommerciauxDAO
    {
        public CommerciauxEntity getActiveCommerciauxByEmail(string Email)
        {

            return getActiveCommercialByEmail(Email);
        }
    }
}
