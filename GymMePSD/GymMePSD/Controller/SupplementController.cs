using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD
{
    public class SupplementController
    {
        public static List<MsSupplement> GetAll()
        {
            return SupplementRespository.GetAll();
        }
    }
}