using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Factories
{

    public class SupplementFactory
    {
        public static MsSupplement Create(int supplementId, string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            MsSupplement newSupplement = new MsSupplement()
            {
                SupplementID = supplementId,
                SupplemetName = supplementName,
                SupplementExpiryDate = supplementExpiryDate,
                SupplementPrice = supplementPrice,
                SupplementTypeID = supplementTypeID
            };

            return newSupplement;
        }
    }
}