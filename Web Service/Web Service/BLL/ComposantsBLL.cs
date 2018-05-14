using Madera.ClassLibrary.Model;
using Madera.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera.ClassLibrary.BLL
{
    public class ComposantsBLL : ComposantsDAO
    {
        public List<ComposantsEntity> getIsolationComposant()
        {
            return getIsolateComposant();
        }

        public List<ComposantsEntity> getAllCouvertureComposant()
        {
            return getCouvertureComposant();
        }
    }
}