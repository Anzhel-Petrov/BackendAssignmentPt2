using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public static class SessionExtensions
    {
        // These methods serialize objects into the JavaScript Object Notation format, making it easy to store and retrieve Cart objects.
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) :
            JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
