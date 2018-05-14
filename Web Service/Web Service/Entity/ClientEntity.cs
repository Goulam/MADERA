using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Service.Entity
{
    public class ClientEntity
    {
        public int Cli_Index { get; set; }
        public string Cli_Nom { get; set; }
        public string Cli_Prenom { get; set; }
        public string Cli_Adresse { get; set; }
        public string Cli_Email { get; set; }
        public string Cli_Phone { get; set; }
        public Nullable<int> Cli_Age { get; set; }
        public string Cli_Ville { get; set; }
        public string Cli_CP { get; set; }
        public Nullable<int> Cli_Actif { get; set; }
    }
}
