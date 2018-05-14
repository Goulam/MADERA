using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public abstract class ComposantsDAO
    {
        //
        // SELECT
        //
        public ComposantsEntity getActiveComposantById(int IdComposants)
        {
            using(var context = new MADERA_V1Entities())
            {
                var composant = (from c in context.MDR_Composants
                                 where c.Comp_Index == IdComposants && c.Comp_Actif == 1
                                 select new ComposantsEntity
                                 {
                                     Comp_Index = c.Comp_Index,
                                     Comp_Actif = c.Comp_Actif,
                                     Comp_Couleur = c.Comp_Couleur,
                                     Comp_Nom = c.Comp_Nom,
                                     Comp_Type = c.Comp_Type
                                 }).SingleOrDefault();

                return composant;
            }
        }
        // 
        // SELECT ALL
        //
        public List<ComposantsEntity> getAllComposant()
        {
            using (var context = new MADERA_V1Entities())
            {
                var composant = (from c in context.MDR_Composants
                                 select new ComposantsEntity
                                 {
                                     Comp_Index = c.Comp_Index,
                                     Comp_Actif = c.Comp_Actif,
                                     Comp_Couleur = c.Comp_Couleur,
                                     Comp_Nom = c.Comp_Nom,
                                     Comp_Type = c.Comp_Type
                                 }).ToList();

                return composant;
            }
        }

        public List<ComposantsEntity> getIsolateComposant()
        {
            using (var context = new MADERA_V1Entities())
            {
                var composant = (from c in context.MDR_Composants
                                 where c.Comp_Type == "Isolation"
                                 select new ComposantsEntity
                                 {
                                     Comp_Index = c.Comp_Index,
                                     Comp_Actif = c.Comp_Actif,
                                     Comp_Couleur = c.Comp_Couleur,
                                     Comp_Nom = c.Comp_Nom,
                                     Comp_Type = c.Comp_Type
                                 }).ToList();

                return composant;
            }
        }

        public List<ComposantsEntity> getCouvertureComposant()
        {
            using (var context = new MADERA_V1Entities())
            {
                var composant = (from c in context.MDR_Composants
                                 where c.Comp_Type == "Couverture"
                                 select new ComposantsEntity
                                 {
                                     Comp_Index = c.Comp_Index,
                                     Comp_Actif = c.Comp_Actif,
                                     Comp_Couleur = c.Comp_Couleur,
                                     Comp_Nom = c.Comp_Nom,
                                     Comp_Type = c.Comp_Type
                                 }).ToList();

                return composant;
            }
        }
        //
        // CREATE
        //
        public bool createComposant(ComposantsEntity composants)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Composants addComposant = new MDR_Composants();

                addComposant.Comp_Actif = 1;
                addComposant.Comp_Couleur = composants.Comp_Couleur;
                addComposant.Comp_Nom = composants.Comp_Nom;
                addComposant.Comp_Type = composants.Comp_Type;

                try
                {
                    context.MDR_Composants.Add(addComposant);
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
        // UPDATE
        //
        public bool updateComposant(ComposantsEntity composants)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Composants addComposant = (from c in context.MDR_Composants
                                               where c.Comp_Index == composants.Comp_Index
                                               select c).SingleOrDefault();

                addComposant.Comp_Actif = composants.Comp_Actif;
                addComposant.Comp_Couleur = composants.Comp_Couleur;
                addComposant.Comp_Nom = composants.Comp_Nom;
                addComposant.Comp_Type = composants.Comp_Type;
                addComposant.Comp_Index = composants.Comp_Index;

                try
                {
                    context.MDR_Composants.Add(addComposant);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        //
        // DELETE
        //
        public bool disabled(int IdComposant)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Composants addComposant = (from c in context.MDR_Composants
                                               where c.Comp_Index == IdComposant
                                               select c).SingleOrDefault();

                addComposant.Comp_Actif = 0;

                try
                {
                    context.MDR_Composants.Add(addComposant);
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
