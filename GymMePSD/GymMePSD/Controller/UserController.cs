using GymMePSD.Handler;
using GymMePSD.Model;
using GymMePSD.Utils;
using GymMePSD.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GymMePSD.Controller
{
    public class UserController
    {
        public static bool CreateUser(string username, string email, DateTime DOB, string gender, string role, string password)
        {
            return UserHandler.CreateUser(username, email, DOB, gender, role, password);
        }

        public static bool LoginUser(string username, string password)
        {
            return UserHandler.LoginUser(username, password);
        }

        public static List<MsUser> GetAllUsers()
        {
            return UserHandler.GetAllUser();
        }


    }
}