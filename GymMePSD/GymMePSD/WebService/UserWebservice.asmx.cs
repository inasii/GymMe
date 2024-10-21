using GymMePSD.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GymMePSD.WebService
{
    /// <summary>
    /// Summary description for UserWebservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebservice : System.Web.Services.WebService
    {

        [WebMethod]
        public string CreateUser(string username, string email, DateTime DOB, string gender, string role,string password )
        {
            return JSONHandler.Encode(UserHandler.CreateUser(username, email, DOB, gender, role, password));
        }

        [WebMethod]
        public string LoginUser(string username, string password)
        {
            return JSONHandler.Encode(UserHandler.LoginUser(username, password));
        }

        [WebMethod]
        public string GetAllUser()
        {
            return JSONHandler.Encode(UserHandler.GetAllUser());
        }
    }
}
