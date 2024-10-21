using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Handler
{
    public class SupplementHandler
    {
        public static string AddSupplement(int supplementId, string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            SupplementRespository.AddSupplement(supplementId, supplementName, supplementExpiryDate, supplementPrice, supplementTypeID);
            return "Succesfully added supplement " + supplementName;
        }

        public static List<MsSupplement> GetAll()
        {
            return SupplementRespository.GetAll();
        }
    }
}