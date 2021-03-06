using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ordinanceMulti_tenantCore.application.Infermiers;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.Web.ViewModels;

namespace ordinanceMulti_tenantCore.Web.Controllers
{
    public class InfermierController : Controller
    {
        #region Properties
        private readonly IInfermierService _infermierService;
        #endregion

        #region Constructor
        public InfermierController(IInfermierService infermierService)
        {
            _infermierService = infermierService;
        }
        #endregion

        #region View
        public IActionResult Index()
        {
            return View(new InfermierViewModel());
        }

        public IActionResult DeleteInfermier(int infermierId)
        {
            _infermierService.DeleteInfermier(infermierId);

            return RedirectToAction("Index", "Infermier");
            //return View();
        }

        [HttpGet]
        public IActionResult AddInfermier()
        {
            return View();
        }

        public IActionResult Details(InfermierViewModel model, int infermierId)
        {
            model.LoadData(infermierId);
            return View(model);
        }

        public IActionResult EditUpdate(InfermierViewModel model, int infermierId)
        {
            model.LoadData(infermierId);
            return View(model);
        }
        #endregion

        #region Add Infermier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInfermier(InfermierViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _infermierService.AddInfermier(PrepareInfermierSubmissionModel(model));
            return RedirectToAction("Index", "Infermier");
            //return View(model);
        }
        #endregion

        #region Edit Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUpdate(InfermierViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _infermierService.UpdateInfermier(PrepareInfermierUpdateSubmissionModel(model));
            return RedirectToAction("Index", "Infermier");
            //return View(model);
        }
        #endregion

        #region Private Methods
        private InfermierSubmissionModel PrepareInfermierSubmissionModel(InfermierViewModel model)
        {
            return new InfermierSubmissionModel
            {
                Infermier_FirstName = model.Infermier_FirstName,
                Infermier_LastName = model.Infermier_LastName,
                Infermier_NrPhone = model.Infermier_NrPhone,
                Infermier_Address = model.Infermier_Address
            };
        }

        private InfermierUpdateSubmissionModel PrepareInfermierUpdateSubmissionModel(InfermierViewModel model)
        {
            return new InfermierUpdateSubmissionModel
            {
                Id = model.Id,
                Infermier_FirstName = model.Infermier_FirstName,
                Infermier_LastName = model.Infermier_LastName,
                Infermier_NrPhone = model.Infermier_NrPhone,
                Infermier_Address = model.Infermier_Address
            };
        }
        #endregion
    }
}