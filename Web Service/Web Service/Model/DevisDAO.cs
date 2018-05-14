using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.Model
{
    public class DevisDAO
    {
        //
        // SELECT ACTIVE 
        //
        public DevisEntity getActiveDevisById(int IdDevis)
        {
            using ( var context = new MADERA_V1Entities())
            {
                var devis = (from d in context.MDR_Devis
                             where d.Dev_Index == IdDevis && d.Dev_Actif == 1
                             select new DevisEntity
                             {
                                 Dev_Index = d.Dev_Index,
                                 Dev_Actif = d.Dev_Actif,
                                 Dev_Prix = d.Dev_Prix
                             }).SingleOrDefault();

                return devis;
            }
        }
        //
        // SELECT ALL
        //
        public DevisEntity getAllDevisById(int IdDevis)
        {
            using (var context = new MADERA_V1Entities())
            {
                var devis = (from d in context.MDR_Devis
                             where d.Dev_Index == IdDevis
                             select new DevisEntity
                             {
                                 Dev_Index = d.Dev_Index,
                                 Dev_Actif = d.Dev_Actif,
                                 Dev_Prix = d.Dev_Prix
                             }).SingleOrDefault();

                return devis;
            }
        }
        //
        // CREATE
        //
        public bool createDevis(DevisEntity devis)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Devis addDevis = new MDR_Devis();

                addDevis.Dev_Actif = devis.Dev_Actif;
                addDevis.Dev_Prix = devis.Dev_Prix;

                try
                {
                    context.MDR_Devis.Add(addDevis);
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
        // UPDATE
        //
        public bool updateDevis(DevisEntity devis)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Devis addDevis = (from d in context.MDR_Devis
                                      where d.Dev_Index == devis.Dev_Index
                                      select d).SingleOrDefault();

                addDevis.Dev_Actif = devis.Dev_Actif;
                addDevis.Dev_Prix = devis.Dev_Prix;
                addDevis.Dev_Index = devis.Dev_Index;

                try
                {
                    context.MDR_Devis.Add(addDevis);
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
        public bool deleteDevis(DevisEntity devis)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Devis addDevis = (from d in context.MDR_Devis
                                      where d.Dev_Index == devis.Dev_Index
                                      select d).SingleOrDefault();

                addDevis.Dev_Actif = 0;

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
