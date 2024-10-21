using GymMePSD.Factory;
using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GymMePSD.Handler
{
    public class UserHandler
    {
        public static bool CreateUser(string username, string email, DateTime DOB, string gender, string role, string password)
        {
            MsUser oldUser = UserRepository.GetUserByUsername(username);
            if (oldUser != null)
            {
                return false;
            }

            MsUser newUser = UserFactory.CreateUser(username, email, DOB, gender, role, password);
            UserRepository.CreateUser(username, email, DOB, gender, role, password);
            return true;
        }

        public static bool LoginUser(string username, string password)
        {
            MsUser user = UserRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            if (user.UserPassword != password)
            {
                return false;
            }
            return true;
        }


        public static List<MsUser> GetAllUser()
        {
            return UserRepository.GetAllUsers();
        }


    }
}