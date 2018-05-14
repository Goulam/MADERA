using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Model;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.BLL
{
    public class ClientBLL : ClientDAO
    {
        public bool insertClientInDb(ClientEntity client)
        {
            try
            {
                createClient(client);
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public List<ClientEntity> getAll()
        {
            return GetAll();
        }

        public List<ClientEntity> getSearchAll(string search)
        {
            return ClientBLL.GetSearchAll(search);
        }
    }
}
