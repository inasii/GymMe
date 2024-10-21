using GymMePSD.Factory;
using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Repositories
{
    public class UserRepository
    {
        public static DatabaseGYMEntities5 db = Singleton.GetInstance();

        // create
        public static MsUser CreateUser(string username, string email, DateTime DOB, string gender, string role, string password)
        {

             MsUser newuser = UserFactory.CreateUser(username,email,DOB,gender,role,password);
             db.MsUsers.Add(newuser);
             db.SaveChanges();
             return newuser;
 
        }

        public static MsUser GetUserByUsernameAndPassword(string username, string password)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
        }

        public static MsUser GetUserByUsername(string username)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserName == username);
        }

        public static MsUser GetUserByRole(string role)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserRole == role);
        }

        public static List<MsUser> GetAllUsers()
        {
            return db.MsUsers.ToList();
        }

    }
}