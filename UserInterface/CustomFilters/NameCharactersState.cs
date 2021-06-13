using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.Models;

namespace UserInterface.CustomFilters
{
    public class NameCharactersState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var incomingDict = context.ActionArguments.Where(i => i.Key == "model").FirstOrDefault();
            var model = (UserRegisterViewModel)incomingDict.Value;
            if (model.Name.Length < 5)
            {
                context.Result = new RedirectResult("\\Home\\Error");
            }
        }
    }
}
