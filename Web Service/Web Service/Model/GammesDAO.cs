using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public abstract class GammesDAO
    {
        //
        // SELECT ACTIVE 
        //
        public GammesEntity selectActiveGamme(int IdGamme)
        {
            using(var context = new MADERA_V1Entities())
            {
                var gamme = (from g in context.MDR_Gammes
                             where g.Gam_Index == IdGamme && g.Gam_Actif == 1
                             select new GammesEntity
                             {
                                 Gam_Actif = g.Gam_Actif,
                                 Gam_Index = g.Gam_Index,
                                 Gam_Nom = g.Gam_Nom
                             }).SingleOrDefault();
                return gamme;
            }
        }
        //
        // SELECT ALL
        //
        public List<GammesEntity> selectAllGamme()
        {
            using (var context = new MADERA_V1Entities())
            {
                var gamme = (from g in context.MDR_Gammes
                             select new GammesEntity
                             {
                                 Gam_Actif = g.Gam_Actif,
                                 Gam_Index = g.Gam_Index,
                                 Gam_Nom = g.Gam_Nom
                             }).ToList();
                return gamme;
            }
        }
        //
        // CREATE
        //
        public bool createGamme(GammesEntity gamme)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Gammes addGamme = new MDR_Gammes();

                addGamme.Gam_Actif = 1;
                addGamme.Gam_Nom = gamme.Gam_Nom;

                try
                {
                    context.MDR_Gammes.Add(addGamme);
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
        public bool updateGamme(GammesEntity gamme)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Gammes addGamme = (from g in context.MDR_Gammes
                                       where g.Gam_Index == gamme.Gam_Index
                                       select g).SingleOrDefault();

                addGamme.Gam_Actif = gamme.Gam_Actif;
                addGamme.Gam_Nom = gamme.Gam_Nom;

                try
                {
                    context.MDR_Gammes.Add(addGamme);
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
        public bool disabledGamme(int IdGamme)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Gammes addGamme = (from g in context.MDR_Gammes
                                       where g.Gam_Index == IdGamme
                                       select g).SingleOrDefault();

                addGamme.Gam_Actif = 0;

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
