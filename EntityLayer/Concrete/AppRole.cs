﻿using EntityLayer.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppRole : IdentityRole<int>,ITable
    {
    }
}
