using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.CustomExtensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object val)
        {
            string data = JsonConvert.SerializeObject(val);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, string key) where T:class ,new()
        {
            string setVal = session.GetString(key);
            if (setVal != null)
            {
               return JsonConvert.DeserializeObject<T>(setVal);

            }return null;
        }
    }
}
