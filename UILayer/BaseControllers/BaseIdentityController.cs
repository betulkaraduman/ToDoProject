﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.BaseControllers
{
    public class BaseIdentityController : Controller
    {
       protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> LoginUser()
        {

            return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        protected void Error(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
