using GymMePSD.Handler;
using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GymMePSD.WebService
{
    /// <summary>
    /// Summary description for SupplementWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SupplementWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<MsSupplement> GetAll()
        {
            return SupplementHandler.GetAll();
        }

        [WebMethod]
        public string AddSupplement(int supplementId, string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            return SupplementHandler.AddSupplement(supplementId, supplementName, supplementExpiryDate, supplementPrice, supplementTypeID);
        }
    }
}
