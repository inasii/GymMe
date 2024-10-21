using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMePSD.Utils
{
    public class JsonUtils
    {
        // Encode
        public static string Encode(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // Decode
        public static T Decode<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}