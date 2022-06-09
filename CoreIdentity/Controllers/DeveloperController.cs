using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoreIdentity.Controllers
{
    public class DeveloperController : Controller
    {
        [Authorize(Roles = "Admin,Developer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
