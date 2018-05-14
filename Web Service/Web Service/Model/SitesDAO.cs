using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public class SitesDAO
    {
        //
        // SELECT ACTIVE
        //
        public SitesEntity getActiveSitesById(int IdSite)
        {
            using(var context = new MADERA_V1Entities())
            {
                var site = (from s in context.MDR_Sites
                            where s.Sts_Index == IdSite && s.Sts_Actif == 1
                            select new SitesEntity
                            {
                                Sts_Actif = s.Sts_Actif,
                                Sts_Index = s.Sts_Index,
                                Sts_Ville = s.Sts_Ville
                            }).SingleOrDefault();
                return site;
            }
        }
        //
        // SELECT ALL
        //
        public SitesEntity getAllSitesById(int IdSite)
        {
            using (var context = new MADERA_V1Entities())
            {
                var site = (from s in context.MDR_Sites
                            where s.Sts_Index == IdSite 
                            select new SitesEntity
                            {
                                Sts_Actif = s.Sts_Actif,
                                Sts_Index = s.Sts_Index,
                                Sts_Ville = s.Sts_Ville
                            }).SingleOrDefault();
                return site;
            }
        }
        //
        // CREATE 
        //
        public bool createSites(SitesEntity site)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Sites addSite = new MDR_Sites();

                addSite.Sts_Actif = 1;
                addSite.Sts_Ville = site.Sts_Ville;

                try
                {
                    context.MDR_Sites.Add(addSite);
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
        public bool updateSite(SitesEntity site)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Sites addSite = (from s in context.MDR_Sites
                                     where s.Sts_Index == site.Sts_Index
                                     select s).SingleOrDefault();

                addSite.Sts_Actif = site.Sts_Actif;
                addSite.Sts_Ville = site.Sts_Ville;
                addSite.Sts_Index = site.Sts_Index;

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
        public bool disabledSite(int IdSite)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Sites addSite = (from s in context.MDR_Sites
                                     where s.Sts_Index == IdSite
                                     select s).SingleOrDefault();

                addSite.Sts_Actif = 0;

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
