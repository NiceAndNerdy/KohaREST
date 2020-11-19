using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

using System.Web.Script.Serialization;

namespace KohaREST
{
    public static class Serializer
    {
        public static T Deserialize<T>(string JSON)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(JSON, settings);
        }

        public static IEnumerable<T> DeserializeIEnumerable<T>(string JSON)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<IEnumerable<T>>(JSON, settings);
        }

        public static string Serialize<T>(T Object)
        {
            return JsonConvert.SerializeObject(Object);
        }
    }
}
