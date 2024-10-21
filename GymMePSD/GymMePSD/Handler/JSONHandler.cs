using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;

namespace GymMePSD.Handler
{
    public class JSONHandler
    {
        // Encode
        public static string Encode(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // Decode
        public static T Decode<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}