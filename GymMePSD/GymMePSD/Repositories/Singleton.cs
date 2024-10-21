using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Repositories
{
    public class Singleton
    {
        public static DatabaseGYMEntities5 instance;

        public static DatabaseGYMEntities5 GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseGYMEntities5();
            }
            return instance;
        }
    }
}