using CryptoApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

using System.Security.Claims;

namespace CryptoApp.Controllers
{
    public class NewWallet : Controller
    {


        public IActionResult Index()
        {
            //add2

            return View();
        }
    }
}
