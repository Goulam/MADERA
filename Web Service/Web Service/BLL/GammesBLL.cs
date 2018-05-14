using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Model;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.BLL
{
    public class GammesController : GammesDAO
    {
        public List<GammesEntity> selectAllGames()
        {
            return selectAllGamme();
        }
    }
}
