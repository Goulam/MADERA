using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public class ModelesDAO
    {
        //
        // SELECT ACTIVE 
        //
        public ModelesEntity getActiveModelesById(int IdModeles)
        {
            using (var context = new MADERA_V1Entities())
            {
                var modele = (from m in context.MDR_Modeles
                             where m.Model_Index == IdModeles && m.Model_Actif == 1
                             select new ModelesEntity
                             {
                                 Model_Actif = m.Model_Actif,
                                 Model_Index = m.Model_Index,
                                 Model_Nom = m.Model_Nom
                             }).SingleOrDefault();

                return modele;
            }
        }
        //
        // SELECT ALL 
        //
        public ModelesEntity getAllModelesById(int IdModeles)
        {
            using (var context = new MADERA_V1Entities())
            {
                var modele = (from m in context.MDR_Modeles
                              where m.Model_Index == IdModeles
                              select new ModelesEntity
                              {
                                  Model_Actif = m.Model_Actif,
                                  Model_Index = m.Model_Index,
                                  Model_Nom = m.Model_Nom
                              }).SingleOrDefault();

                return modele;
            }
        }
        //
        // CREATE 
        //
        public bool createModele(ModelesEntity modele)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Modeles addModeles = new MDR_Modeles();

                addModeles.Model_Actif = 1;
                addModeles.Model_Nom = modele.Model_Nom;

                try
                {
                    context.MDR_Modeles.Add(addModeles);
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
        public bool updateModele(ModelesEntity modele)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Modeles addModeles = (from m in context.MDR_Modeles
                                         where m.Model_Index == modele.Model_Index
                                         select m).SingleOrDefault();

                addModeles.Model_Actif = modele.Model_Actif;
                addModeles.Model_Nom = modele.Model_Nom;
                addModeles.Model_Index = modele.Model_Index;

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
        //
        // DELETE
        //
        public bool disabledModele(int IdModele)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Modeles addModeles = (from m in context.MDR_Modeles
                                          where m.Model_Index == IdModele
                                          select m).SingleOrDefault();

                addModeles.Model_Actif = 0;

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
