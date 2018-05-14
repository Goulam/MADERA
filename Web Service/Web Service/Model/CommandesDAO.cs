using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.Model
{
    public class CommandesDAO
    {
        //
        // Fonction de récupération 
        // 
        public CommandesEntity getActiveCommandeById(int IdCommande)
        {
            using (var context = new MADERA_V1Entities())
            {
                var commande = (from c in context.MDR_Commandes
                                where c.Comma_Index == IdCommande && c.Comma_Index == 1
                                select new CommandesEntity
                                {
                                    Comma_Index = c.Comma_Index,
                                    Comma_Actif = c.Comma_Actif,
                                    Comma_Prix = c.Comma_Prix
                                }).SingleOrDefault();

                return commande;
            }
        }
        //
        // Fonction de récupération peu importe actif ou non 
        // 
        public CommandesEntity getAllCommandeById(int IdCommande)
        {
            using (var context = new MADERA_V1Entities())
            {
                var commande = (from c in context.MDR_Commandes
                                where c.Comma_Index == IdCommande
                                select new CommandesEntity
                                {
                                    Comma_Index = c.Comma_Index,
                                    Comma_Actif = c.Comma_Actif,
                                    Comma_Prix = c.Comma_Prix
                                }).SingleOrDefault();

                return commande;
            }
        }
        //
        // Fonction de création d'une commande 
        //
        public bool createCommande(CommandesEntity commande)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Commandes addCommandes = new MDR_Commandes();

                addCommandes.Comma_Actif = 1;
                addCommandes.Comma_Prix = commande.Comma_Prix;

                try
                {
                    context.MDR_Commandes.Add(addCommandes);
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
        // Fonction d'udpadte d'une commande
        //
        public bool updateCommande(CommandesEntity commande)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Commandes updatingCommande = (from c in context.MDR_Commandes
                                           where c.Comma_Index == commande.Comma_Index
                                           select c).SingleOrDefault();

                updatingCommande.Comma_Actif = commande.Comma_Actif;
                updatingCommande.Comma_Prix = commande.Comma_Prix;

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
        // Fonction de suppression d'une commande
        //
        public bool disabledCommande(int IdCommande)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Commandes updatingCommande = (from c in context.MDR_Commandes
                                                  where c.Comma_Index == IdCommande
                                                  select c).SingleOrDefault();

                updatingCommande.Comma_Index = 0;

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
