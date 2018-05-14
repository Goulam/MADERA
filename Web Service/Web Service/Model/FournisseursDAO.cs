using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public class FournisseursDAO
    {
        //
        // SELECT ACTIVE
        //
        public FournisseursEntity selectActiveFournisseur(int IdFournisseur)
        {
            using(var context = new MADERA_V1Entities())
            {
                var fournisseur = (from f in context.MDR_Fournisseurs
                                   where f.Four_Index == IdFournisseur && f.Four_Actif == 1
                                   select new FournisseursEntity
                                   {
                                       Four_Actif = f.Four_Actif,
                                       Four_Index = f.Four_Index,
                                       Four_Nom = f.Four_Nom
                                   }).SingleOrDefault();

                return fournisseur;
            }
        }
        //
        // SELECT ALL
        //
        public FournisseursEntity selectAllFournisseur(int IdFournisseur)
        {
            using (var context = new MADERA_V1Entities())
            {
                var fournisseur = (from f in context.MDR_Fournisseurs
                                   where f.Four_Index == IdFournisseur
                                   select new FournisseursEntity
                                   {
                                       Four_Actif = f.Four_Actif,
                                       Four_Index = f.Four_Index,
                                       Four_Nom = f.Four_Nom
                                   }).SingleOrDefault();

                return fournisseur;
            }
        }
        //
        // CREATE 
        //
        public bool createFournisseur(FournisseursEntity fournisseur)
        {
            using ( var context = new MADERA_V1Entities())
            {
                MDR_Fournisseurs addFournisseur = new MDR_Fournisseurs();

                addFournisseur.Four_Actif = 1;
                addFournisseur.Four_Nom = fournisseur.Four_Nom;

                try
                {
                    context.MDR_Fournisseurs.Add(addFournisseur);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        //
        // UPDATE 
        //
        public bool updateFournisseur(FournisseursEntity fournisseur)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Fournisseurs addFournisseur = (from f in context.MDR_Fournisseurs
                                                   where f.Four_Index == fournisseur.Four_Index
                                                   select f).SingleOrDefault();

                addFournisseur.Four_Actif = fournisseur.Four_Actif;
                addFournisseur.Four_Nom = fournisseur.Four_Nom;
                addFournisseur.Four_Index = fournisseur.Four_Index;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        //
        // DELETE 
        //
        public bool disabledFournisseur(int IdFournisseur)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Fournisseurs addFournisseur = (from f in context.MDR_Fournisseurs
                                                   where f.Four_Index == IdFournisseur
                                                   select f).SingleOrDefault();

                addFournisseur.Four_Actif = 0;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
