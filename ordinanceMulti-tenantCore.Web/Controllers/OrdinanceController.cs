using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.application.Ordinances;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.Web.ViewModels.Orinances;

namespace ordinanceMulti_tenantCore.Web.Controllers
{
    [Authorize]
    public class OrdinanceController : Controller
    {
        #region Properties
        private readonly IOrdinanceService _ordinanceService;
        private readonly IUserHelper _userHelper;
        #endregion

        #region Constructor
        public OrdinanceController(IOrdinanceService ordinanceService, IUserHelper userHelper)
        {
            _ordinanceService = ordinanceService;
            _userHelper = userHelper;
        }
        #endregion

        #region View
        // GET: Ordinance
        public IActionResult Index()
        {
            return View(new AddViewModel());
        }

        [HttpGet]
        public IActionResult AddOrdinance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrdinance(AddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _ordinanceService.AddOrdinance(PrepareOrdinanceSubmissionModel(model));
            HttpContextHelper.Context.Items.Add("TENANT_" + model.Ordinance_Name + "_DB", "tenant");
            return RedirectToAction("Sporteli");
            //return View(model);
        }

        public IActionResult Sporteli()
        {
            return View();
        }
        #endregion

        #region Private Methods
        private OrdinanceSubmissionModel PrepareOrdinanceSubmissionModel(AddViewModel model)
        {
            return new OrdinanceSubmissionModel
            {
                Ordinance_Name = model.Ordinance_Name,
                Sector = model.Sector,
                Ordinance_Address = model.Ordinance_Address
            };
        }
        #endregion
    }
}