using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera.ClassLibrary.Entity;

namespace Madera.ClassLibrary.Model
{
    public class EtatPaiementDAO
    {
        //
        // SELECT ACTIVE
        //
        public EtatPaiementEntity getActiveEtatPaiement(int IdEtatPaiement)
        {
            using( var context = new MADERA_V1Entities())
            {
                var Etat = (from e in context.MDR_Etat_Paiement
                            where e.EPai_Index == IdEtatPaiement && e.EPai_Actif == 1
                            select new EtatPaiementEntity
                            {
                                EPai_Actif = e.EPai_Actif,
                                EPai_Date = e.EPai_Date,
                                EPai_Index = e.EPai_Index,
                                EPai_Etat = e.EPai_Etat
                            }).SingleOrDefault();

                return Etat;
            }
        }
        //
        // SELECT ALL
        //
        public EtatPaiementEntity getAllEtatPaiement(int IdEtatPaiement)
        {
            using (var context = new MADERA_V1Entities())
            {
                var Etat = (from e in context.MDR_Etat_Paiement
                            where e.EPai_Index == IdEtatPaiement
                            select new EtatPaiementEntity
                            {
                                EPai_Actif = e.EPai_Actif,
                                EPai_Date = e.EPai_Date,
                                EPai_Index = e.EPai_Index,
                                EPai_Etat = e.EPai_Etat
                            }).SingleOrDefault();

                return Etat;
            }
        }
        //
        // CREATE
        //
        public bool createEtatPaiement(EtatPaiementEntity etat)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Etat_Paiement addEtat = new MDR_Etat_Paiement();

                addEtat.EPai_Actif = 1;
                addEtat.EPai_Date = etat.EPai_Date;
                addEtat.EPai_Etat = etat.EPai_Etat;
                
                try
                {
                    context.MDR_Etat_Paiement.Add(addEtat);
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
        public bool updateEtatPaiement(EtatPaiementEntity etat)
        {
            using(var context = new MADERA_V1Entities())
            {
                MDR_Etat_Paiement addEtat = (from e in context.MDR_Etat_Paiement
                                             where e.EPai_Index == etat.EPai_Index
                                             select e).SingleOrDefault();

                addEtat.EPai_Actif = etat.EPai_Actif;
                addEtat.EPai_Date = etat.EPai_Date;
                addEtat.EPai_Etat = etat.EPai_Etat;
                addEtat.EPai_Index = etat.EPai_Index;

                try
                {
                    context.MDR_Etat_Paiement.Add(addEtat);
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
        public bool disabledEtatPaiement(int IdEtatPaiement)
        {
            using (var context = new MADERA_V1Entities())
            {
                MDR_Etat_Paiement addEtat = (from e in context.MDR_Etat_Paiement
                                             where e.EPai_Index == IdEtatPaiement
                                             select e).SingleOrDefault();

                addEtat.EPai_Actif = 0;

                try
                {
                    context.MDR_Etat_Paiement.Add(addEtat);
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
