using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.Model
{
    public abstract class CommerciauxDAO
    {
        //
        //Fonction de récupération d'un commercial (Il doit etre actif)
        //
        public CommerciauxEntity getActiveCommercialById(int IdCommercial)
        {
            using(var context = new MADERA_V1Entities())
            {
                var commercial = (from c in context.MDR_Commerciaux
                                  where c.Com_Index == IdCommercial && c.Com_Actif == 1
                                  select new CommerciauxEntity
                                  {
                                      Com_Actif = c.Com_Actif,
                                      Com_Identifiant = c.Com_Identifiant,
                                      Com_Index = c.Com_Index,
                                      Com_Mdp = c.Com_Mdp,
                                      Com_Nom = c.Com_Nom
                                  }).SingleOrDefault();

                return commercial;
            }
        }
        //
        //Fonction de récupération d'un commercial par Email (Il doit etre actif)
        //
        public CommerciauxEntity getActiveCommercialByEmail(string Email)
        {
            using (var context = new MADERA_V1Entities())
            {
                var commercial = (from c in context.MDR_Commerciaux
                                  where c.Com_Identifiant == Email && c.Com_Actif == 1
                                  select new CommerciauxEntity
                                  {
                                      Com_Actif = c.Com_Actif,
                                      Com_Identifiant = c.Com_Identifiant,
                                      Com_Index = c.Com_Index,
                                      Com_Mdp = c.Com_Mdp,
                                      Com_Nom = c.Com_Nom
                                  }).SingleOrDefault();

                return commercial;
            }
        }
        //
        // Fonction de récupération d'une commande par ID (Toutes commandes, même inactives) 
        //
        public CommerciauxEntity getAllCommercialById(int IdCommercial)
        {
            using (var context = new MADERA_V1Entities())
            {
                var commercial = (from c in context.MDR_Commerciaux
                                  where c.Com_Index == IdCommercial
                                  select new CommerciauxEntity
                                  {
                                      Com_Actif = c.Com_Actif,
                                      Com_Identifiant = c.Com_Identifiant,
                                      Com_Index = c.Com_Index,
                                      Com_Mdp = c.Com_Mdp,
                                      Com_Nom = c.Com_Nom
                                  }).SingleOrDefault();

                return commercial;
            }
        }
        //
        //Fonction de création d'un commercial
        //
        public bool createCommercial(CommerciauxEntity commercial)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Commerciaux addCommercial = new MDR_Commerciaux();

                addCommercial.Com_Actif = 1;
                addCommercial.Com_Identifiant = commercial.Com_Identifiant;
                addCommercial.Com_Mdp = commercial.Com_Mdp;
                addCommercial.Com_Nom = commercial.Com_Nom;

                try
                {
                    context.MDR_Commerciaux.Add(addCommercial);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception 
                
                e)
                {
                    return false;
                }

            }
        }
        //
        //Fonction de modification d'un commercial
        //
        public bool updateCommercial(CommerciauxEntity commercial)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Commerciaux updatingCommercial = (from c in context.MDR_Commerciaux
                                                      where c.Com_Index == commercial.Com_Index
                                                      select c).SingleOrDefault();

                updatingCommercial.Com_Identifiant = commercial.Com_Identifiant;
                updatingCommercial.Com_Mdp = commercial.Com_Mdp;
                updatingCommercial.Com_Nom = commercial.Com_Nom;

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
        // Fonction de désactivation d'un commercial
        //
        public bool disabledCommercial(int IdCommercial)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Commerciaux updatingCommercial = (from c in context.MDR_Commerciaux
                                                      where c.Com_Index == IdCommercial
                                                      select c).SingleOrDefault();

                updatingCommercial.Com_Actif = 0;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
