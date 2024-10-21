using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GymMePSD.Factories.TransactionFactory;

namespace WebApplication2.Repository
{
    public class TransactionRepository
    {
        //private readonly DatabaseGYMEntities _db;

        //DatabaseGYMEntities db = Singleton.GetInstance();
        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader GetHeaderById(int id)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();
            return db.TransactionHeaders.Find(id);
        }

        public static bool UpdateTHeader(TransactionHeader newTransaction)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();
            TransactionHeader oldTransaction = db.TransactionHeaders.Find(newTransaction.TransactionID);

            if (oldTransaction == null)
            {
                return false;

            }

            oldTransaction.UserID = newTransaction.UserID;
            oldTransaction.TransactionDate = newTransaction.TransactionDate;
            oldTransaction.Status = newTransaction.Status;

            db.SaveChanges();

            return true;

        }

        public static void addHeader(TransactionHeader header)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static void AddDetail(TransactionDetail detail)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        public static List<TransactionDetail> GetDetailByTransactionId(int transactionId)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            return db.TransactionDetails.Where(td => td.TransactionID == transactionId).ToList();
        }

        public static List<MsCart> getCartByUserId(int userId)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            return db.MsCarts.Where(c => c.UserID == userId).ToList();
        }

        public static MsSupplement GetSupplementById(int SupplementID)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            return db.MsSupplements.Find(SupplementID);
        }

        public static MsUser GetUserById(int userId)
        {
            DatabaseGYMEntities5 db = Singleton.GetInstance();

            return db.MsUsers.Find(userId);
        }


        }
}