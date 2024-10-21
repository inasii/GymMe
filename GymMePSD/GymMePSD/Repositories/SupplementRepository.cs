using GymMePSD.Factories;
using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Repositories
{
    public class SupplementRespository
    {
        public static DatabaseGYMEntities5 db = Singleton.GetInstance();
        public static MsSupplement AddSupplement(int supplementId, string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            MsSupplement supplement = SupplementFactory.Create(supplementId, supplementName, supplementExpiryDate, supplementPrice, supplementTypeID);
            db.MsSupplements.Add(supplement);
            db.SaveChanges();
            return supplement;
        }


        public static MsSupplement GetSupplementByID(int supplementID)
        {
            return db.MsSupplements.Find(supplementID);
        }

        public static void updateSupplement()
        {
            db.SaveChanges();
        }

        public static void deleteSupplement(int supplementId)
        {
            MsSupplement tobedeletedSupplement = GetSupplementByID(supplementId);
            db.MsSupplements.Remove(tobedeletedSupplement);
            db.SaveChanges();
        }
        public static List<MsSupplement> GetAll()
        {
            List<MsSupplement> supplements = db.MsSupplements.ToList();
            return supplements;
        }
    }
}