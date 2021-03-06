using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ordinanceMulti_tenantCore.Web.Controllers
{
    public class ClinicController : Controller
    {
        #region Constructor
        public ClinicController()
        {

        }
        #endregion

        #region View
        // GET: Clinic
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        #endregion
    }
}