using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader createNewHeader(int userId, DateTime transactionDate, string status)
        {
            return new TransactionHeader()
            {
                UserID = userId,
                TransactionDate = transactionDate,
                Status = status
            };
        }
        public static TransactionDetail createNewDetail(int transactionId, int supplementId, int quantity)
        {
            return new TransactionDetail()
            {
                TransactionID = transactionId,
                SupplementID = supplementId,
                Quantity = quantity
            };
        }

        public interface ITransactionRepository
        {
            List<TransactionHeader> GetAllTransactions();
            bool UpdateTransactionStatus(int transactionId, string status);
        }
    }
}