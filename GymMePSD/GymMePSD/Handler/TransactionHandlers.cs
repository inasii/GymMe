using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.module;
using GymMePSD.Factories;
using WebApplication2.Repository;
using GymMePSD.Model;
using System.Runtime.Remoting.Messaging;
using GymMePSD.Repositories;


namespace WebApplication2.handler
{
    public class TransactionHandlers
    {
        public static response<List<TransactionHeader>> getAllofHeader()
        {
            List<TransactionHeader> allHeader = TransactionRepository.GetAllTransactionHeaders();

            if (allHeader.Count == 0)
            {
                return new response<List<TransactionHeader>>(false, "No transaction found", null);
            }

            else
            {
                return new response<List<TransactionHeader>>(true, "Transactions found", allHeader);
            }
        }

        public static response<TransactionHeader> updateStatus(int id, string status)
        {
            TransactionHeader header = TransactionRepository.GetHeaderById(id);
            string error = "";

            if (header == null)
            {

                error = "Sorry, no transaction found";
            }
            else if (header.Status.Equals(status))
            {
                error = "Transaction is already handled";
            }

            if (!String.IsNullOrEmpty(error))
            {
                return new response<TransactionHeader>(false, error, null);
            }


            header.Status = status;

            bool updated = TransactionRepository.UpdateTHeader(header);
            if (updated)
            {
                return new response<TransactionHeader>(true, "Yey, successfully updated status", header);
            }
            else
            {
                return new response<TransactionHeader>(false, "Sorry, failed to update status", null);
            }

        }
        public static response<TransactionHeader> addHeader(int userId, DateTime transactionDate, string status)
        {
            TransactionHeader header = TransactionFactory.createNewHeader(userId, transactionDate, status);

            TransactionRepository.addHeader(header);

            return new response<TransactionHeader>(true, "successfully createdd header", header);
        }

        public static response<TransactionDetail> addDetail(int transactionId, int supplementId, int qty)
        {
            TransactionHeader header = TransactionRepository.GetHeaderById(transactionId);

            if (header == null)
            {
                return new response<TransactionDetail>(false, "Transaction not found", null);
            }

            TransactionDetail detail = TransactionFactory.createNewDetail(transactionId, supplementId, qty);
            TransactionRepository.AddDetail(detail);

            return new response<TransactionDetail>(true, "Succesfully created detail", detail);

        }
    }
}