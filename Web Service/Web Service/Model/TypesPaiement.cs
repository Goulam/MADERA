using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public class TypesPaiement
    {
        //
        // SELECT ACTIVE
        //
        public TypesPaiementEntity getActiveTypePaiementById(int IdType)
        {
            using(var context = new MADERA_V1Entities())
            {
                var type = (from t in context.MDR_Types_Paiement
                            where t.TPai_Index == IdType && t.TPai_Actif == 1
                            select new TypesPaiementEntity
                            {
                                TPai_Actif = t.TPai_Actif,
                                TPai_Index = t.TPai_Index,
                                TPai_Nom = t.TPai_Nom
                            }).SingleOrDefault();
                return type;
            }
        }
        //
        // SELECT ALL
        //
        public TypesPaiementEntity getAllTypePaiementById(int IdType)
        {
            using (var context = new MADERA_V1Entities())
            {
                var type = (from t in context.MDR_Types_Paiement
                            where t.TPai_Index == IdType
                            select new TypesPaiementEntity
                            {
                                TPai_Actif = t.TPai_Actif,
                                TPai_Index = t.TPai_Index,
                                TPai_Nom = t.TPai_Nom
                            }).SingleOrDefault();
                return type;
            }
        }
        //
        // CREATE
        //
        public bool createTypePaiement(TypesPaiementEntity type)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Types_Paiement addType = new MDR_Types_Paiement();

                addType.TPai_Actif = 1;
                addType.TPai_Nom = type.TPai_Nom;

                try
                {
                    context.MDR_Types_Paiement.Add(addType);
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
        public bool updateTypePaiement(TypesPaiementEntity type)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Types_Paiement addType = (from t in context.MDR_Types_Paiement
                                              where t.TPai_Index == type.TPai_Index
                                              select t).SingleOrDefault();

                addType.TPai_Actif = type.TPai_Actif;
                addType.TPai_Nom = type.TPai_Nom;
                addType.TPai_Index = type.TPai_Index;

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
        public bool disabledTypePaiement(int IdType)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Types_Paiement addType = (from t in context.MDR_Types_Paiement
                                              where t.TPai_Index == IdType
                                              select t).SingleOrDefault();

                addType.TPai_Actif = 0;

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
