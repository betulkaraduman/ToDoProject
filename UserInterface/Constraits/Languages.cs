using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Constraits
{
    public class Languages : IRouteConstraint
    {
        public List<string> langs = new List<string> { "csharp", "java", "php", "python" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return langs.Contains(values[routeKey].ToString().ToLower());
        }
    }
}
