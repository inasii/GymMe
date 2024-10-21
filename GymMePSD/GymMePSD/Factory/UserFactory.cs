using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(string username, string email, DateTime DOB, string gender, string role, string password)
        {
            MsUser newuser = new MsUser()
            {
                UserName = username,
                UserEmail = email,
                UserDOB = DOB,
                UserGender = gender,
                UserRole = role,
                UserPassword = password
            };
            return newuser;
        }

    }
}