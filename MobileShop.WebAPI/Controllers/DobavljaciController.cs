﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.WebAPI.Services;

namespace MobileShop.WebAPI.Controllers
{
   
    public class DobavljaciController : BaseController<Model.Models.Dobavljaci,object>
    {
        public DobavljaciController(IService<Model.Models.Dobavljaci,object> service) : base(service)
        {

        }
    }
}