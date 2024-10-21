using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.module;
using WebApplication2.handler;
using GymMePSD.Model;

namespace WebApplication2.controller
{
    public class transactionController
    {
        public static response<List<TransactionHeader>> getAllHeader()
        {
            return TransactionHandlers.getAllofHeader();
        }
        public static response<TransactionHeader> updateStatus(int id, string status)
        {
            string error = "";

            if (id == 0 || error != "") //string.IsNullOrEmpty(status)
            {
                error = "All fields are required";
            }
            else if (!status.Equals("Handeld") && !status.Equals("Unhandled"))
            {
                error = "status invalid";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return new response<TransactionHeader>(false, error, null);
            }

            return TransactionHandlers.updateStatus(id, status);
        }

        public static response<TransactionHeader> addHeader(int userId, DateTime transactionDate, string status)
        {

            string error = "";

            if (userId == 0 || status == "" || transactionDate == DateTime.MinValue) //string.IsNullOrEmpty(status)
            {
                error = "All fields are requird";
            }
            else if (transactionDate != DateTime.Now)
            {
                error = "The transaction date must be today";
            }

            else if (!status.Equals("Unhandled"))
            {
                error = "status invalid!";
            }

            if (error != "")
            {
                return new response<TransactionHeader>(false, error, null);
            }

            return TransactionHandlers.addHeader(userId, transactionDate, status);
        }


        public static response<TransactionDetail> addDetail(int transactionId, int supplementId, int qty)
        {
            if (transactionId == 0 || supplementId == 0 || qty == 0)
            {
                return new response<TransactionDetail>(false, "All fields are required", null);
            }
            return TransactionHandlers.addDetail(transactionId, supplementId, qty);
        }

    }
}