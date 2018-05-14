using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.Model
{
    public class ModulesDAO
    {
        //
        // SELECT ACTIVE
        //
        public ModulesEntity getActiveModulesById(int IdModules)
        {
            using (var context = new MADERA_V1Entities())
            {
                var modules = (from m in context.MDR_Modules
                               where m.Mod_Index == IdModules && m.Mod_Actif == 1
                               select new ModulesEntity
                               {
                                   Mod_Actif = m.Mod_Actif,
                                   Mod_Index = m.Mod_Index,
                                   Mod_Date = m.Mod_Date,
                                   Mod_Nom = m.Mod_Nom,
                                   Mod_Prix = m.Mod_Prix
                               }).SingleOrDefault();
                return modules;
            }
        }
        //
        // SELECT ALL
        //
        public ModulesEntity getAllModulesById(int IdModules)
        {
            using (var context = new MADERA_V1Entities())
            {
                var modules = (from m in context.MDR_Modules
                               where m.Mod_Index == IdModules
                               select new ModulesEntity
                               {
                                   Mod_Actif = m.Mod_Actif,
                                   Mod_Index = m.Mod_Index,
                                   Mod_Date = m.Mod_Date,
                                   Mod_Nom = m.Mod_Nom,
                                   Mod_Prix = m.Mod_Prix
                               }).SingleOrDefault();
                return modules;
            }
        }
        //
        // CREATE 
        //
        public bool createModule(ModulesEntity module)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Modules addModule = new MDR_Modules();

                addModule.Mod_Actif = 1;
                addModule.Mod_Date = module.Mod_Date;
                addModule.Mod_Nom = module.Mod_Nom;
                addModule.Mod_Prix = module.Mod_Prix;

                try
                {
                    context.MDR_Modules.Add(addModule);
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
        public bool updateModule(ModulesEntity module)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Modules addModule = (from m in context.MDR_Modules
                                         where m.Mod_Index == module.Mod_Index
                                         select m).SingleOrDefault();

                addModule.Mod_Actif = module.Mod_Actif;
                addModule.Mod_Date = module.Mod_Date;
                addModule.Mod_Nom = module.Mod_Nom;
                addModule.Mod_Prix = module.Mod_Prix;
                addModule.Mod_Index = module.Mod_Index;

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
        public bool disabledModule(int IdModule)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Modules addModule = (from m in context.MDR_Modules
                                         where m.Mod_Index == IdModule
                                         select m).SingleOrDefault();

                addModule.Mod_Actif = 0;

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
