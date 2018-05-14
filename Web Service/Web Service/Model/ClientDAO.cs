using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    
    public abstract class ClientDAO
    {
        //
        // Fonction de récupération d'un client par ID (Le client doit être actif) 
        //
        public ClientEntity getActiveClientById(int IdClient)
        {
            using (var context = new MADERA_V1Entities())
            {
                var numCount1 =
                                (from c in context.MDR_Clients
                                 where c.Cli_Index == IdClient && c.Cli_Actif == 1
                                 select new ClientEntity
                                 {
                                     Cli_Index = c.Cli_Index,
                                     Cli_Adresse = c.Cli_Adresse,
                                     Cli_Age = c.Cli_Age,
                                     Cli_CP = c.Cli_CP,
                                     Cli_Email = c.Cli_Email,
                                     Cli_Nom = c.Cli_Nom,
                                     Cli_Phone = c.Cli_Phone,
                                     Cli_Prenom = c.Cli_Prenom,
                                     Cli_Ville = c.Cli_Ville,
                                     Cli_Actif = c.Cli_Actif
                                 }).SingleOrDefault();

                return numCount1;
            }
            
        }

        public static List<ClientEntity> GetAll()
        {
            using (var context = new MADERA_V1Entities())
            {
                var numCount1 =
                                (from c in context.MDR_Clients
                                 select new ClientEntity
                                 {
                                     Cli_Index = c.Cli_Index,
                                     Cli_Adresse = c.Cli_Adresse,
                                     Cli_Age = c.Cli_Age,
                                     Cli_CP = c.Cli_CP,
                                     Cli_Email = c.Cli_Email,
                                     Cli_Nom = c.Cli_Nom,
                                     Cli_Phone = c.Cli_Phone,
                                     Cli_Prenom = c.Cli_Prenom,
                                     Cli_Ville = c.Cli_Ville,
                                     Cli_Actif = c.Cli_Actif
                                 }).ToList();

                return numCount1;
            }
        }

        public static List<ClientEntity> GetSearchAll(string search)
        {
            using (var context = new MADERA_V1Entities())
            {
                var numCount1 =
                                (from c in context.MDR_Clients
                                 where c.Cli_Nom.Contains(search) || c.Cli_Prenom.Contains(search) || c.Cli_Email.Contains(search)

                                 select new ClientEntity
                                 {
                                     Cli_Index = c.Cli_Index,
                                     Cli_Adresse = c.Cli_Adresse,
                                     Cli_Age = c.Cli_Age,
                                     Cli_CP = c.Cli_CP,
                                     Cli_Email = c.Cli_Email,
                                     Cli_Nom = c.Cli_Nom,
                                     Cli_Phone = c.Cli_Phone,
                                     Cli_Prenom = c.Cli_Prenom,
                                     Cli_Ville = c.Cli_Ville,
                                     Cli_Actif = c.Cli_Actif
                                 }).ToList();

                context.MDR_Clients.Where(c => c.Cli_Nom.Contains(search)).Select(c => new ClientEntity() { }).ToList();


                return numCount1;
            }
        }
        //
        // Fonction de récupération d'un client par ID (Tout clients, actifs ou non) 
        //
        public ClientEntity getActiveOrNotClientById(int IdClient)
        {
            using (var context = new MADERA_V1Entities())
            {
                var client =
                                (from c in context.MDR_Clients
                                 where c.Cli_Index == IdClient
                                 select new ClientEntity
                                 {
                                     Cli_Index = c.Cli_Index,
                                     Cli_Adresse = c.Cli_Adresse,
                                     Cli_Age = c.Cli_Age,
                                     Cli_CP = c.Cli_CP,
                                     Cli_Email = c.Cli_Email,
                                     Cli_Nom = c.Cli_Nom,
                                     Cli_Phone = c.Cli_Phone,
                                     Cli_Prenom = c.Cli_Prenom,
                                     Cli_Ville = c.Cli_Ville,
                                     Cli_Actif = c.Cli_Actif
                                 }).SingleOrDefault();

                return client;
            }

        }
        //
        // Fonction de création d'un client
        //
        public bool createClient(ClientEntity client)
        {
            using (var context = new MADERA_V1Entities())
            {
               
                MDR_Clients addCLient = new MDR_Clients();
                
                addCLient.Cli_Actif = 1;
                addCLient.Cli_Adresse = client.Cli_Adresse;
                addCLient.Cli_Age = client.Cli_Age;
                addCLient.Cli_CP = client.Cli_CP;
                addCLient.Cli_Email = client.Cli_Email;
                addCLient.Cli_Nom = client.Cli_Nom;
                addCLient.Cli_Phone = client.Cli_Phone;
                addCLient.Cli_Prenom = client.Cli_Prenom;
                addCLient.Cli_Ville = client.Cli_Ville;

                

                try
                {
                    context.MDR_Clients.Add(addCLient);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
        }
        //
        // Fonction d'update d'un client 
        //
        public bool updateClient(ClientEntity client)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Clients updatingClient = (from c in context.MDR_Clients
                                               where c.Cli_Index == client.Cli_Index
                                               select c).SingleOrDefault();

                updatingClient.Cli_Actif = client.Cli_Actif;
                updatingClient.Cli_Adresse = client.Cli_Adresse;
                updatingClient.Cli_Age = client.Cli_Age;
                updatingClient.Cli_CP = client.Cli_CP;
                updatingClient.Cli_Email = client.Cli_Email;
                updatingClient.Cli_Nom = client.Cli_Nom;
                updatingClient.Cli_Phone = client.Cli_Phone;
                updatingClient.Cli_Prenom = client.Cli_Prenom;
                updatingClient.Cli_Ville = client.Cli_Ville;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
        // 
        // Fonction de suppression d'un client
        //
        public bool disabledClientById(int IdClient)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Clients updatingClient = (from c in context.MDR_Clients
                                                where c.Cli_Index == IdClient
                                                select c).SingleOrDefault();

                updatingClient.Cli_Actif = 0;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

    }
}
