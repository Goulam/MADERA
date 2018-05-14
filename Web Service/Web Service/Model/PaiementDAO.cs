using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Service.Entity;

namespace Web_Service.Model
{
    public class PaiementDAO
    {
        //
        // SELECT ACTIVE
        //
        public PaiementEntity getActivePaiementByID(int IdPaiement)
        {
            using(var context = new MADERA_V1Entities())
            {
                var paiement = (from p in context.MDR_Paiement
                                where p.Pai_Index == IdPaiement && p.Pai_Actif == 1
                                select new PaiementEntity
                                {
                                    Pai_Actif = p.Pai_Actif,
                                    Pai_Etat = p.Pai_Etat,
                                    Pai_Index = p.Pai_Index,
                                    Pai_Type = p.Pai_Type
                                }).SingleOrDefault();
                return paiement;
            }
        }
        //
        // SELECT ALL
        //
        public PaiementEntity getAllPaiementById(int IdPaiement)
        {
            using (var context = new MADERA_V1Entities())
            {
                var paiement = (from p in context.MDR_Paiement
                                where p.Pai_Index == IdPaiement 
                                select new PaiementEntity
                                {
                                    Pai_Actif = p.Pai_Actif,
                                    Pai_Etat = p.Pai_Etat,
                                    Pai_Index = p.Pai_Index,
                                    Pai_Type = p.Pai_Type
                                }).SingleOrDefault();
                return paiement;
            }
        }
        //
        // CREATE
        //
        public bool createPaiement(PaiementEntity paiement)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Paiement addPaiement = new MDR_Paiement();

                addPaiement.Pai_Actif = 1;
                addPaiement.Pai_Etat = paiement.Pai_Etat;
                addPaiement.Pai_Type = paiement.Pai_Type;

                try
                {
                    context.MDR_Paiement.Add(addPaiement);
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
        public bool updatePaiement(PaiementEntity paiement)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Paiement addPaiement = (from p in context.MDR_Paiement
                                            where p.Pai_Index == paiement.Pai_Index
                                            select p).SingleOrDefault();

                addPaiement.Pai_Actif = paiement.Pai_Actif;
                addPaiement.Pai_Etat = paiement.Pai_Etat;
                addPaiement.Pai_Type = paiement.Pai_Type;
                addPaiement.Pai_Index = paiement.Pai_Index;

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
        public bool disabledPaiement(int IdPaiement)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Paiement addPaiement = (from p in context.MDR_Paiement
                                            where p.Pai_Index == IdPaiement
                                            select p).SingleOrDefault();

                addPaiement.Pai_Actif = 0;

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
