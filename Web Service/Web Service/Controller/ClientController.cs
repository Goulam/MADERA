using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Model;
using Web_Service.Entity;

namespace Web_Service.Controller
{
    public class ClientController : ClientDAO
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
            return ClientController.GetSearchAll(search);
        }
    }
}
