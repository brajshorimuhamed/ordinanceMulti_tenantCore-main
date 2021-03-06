using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ordinanceMulti_tenantCore.application.Doctors;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.Web.ViewModels;

namespace ordinanceMulti_tenantCore.Web.Controllers
{
    public class DoctorController : Controller
    {
        #region Properties
        private readonly IDoctorService _doctorService;
        #endregion

        #region Constructor
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        #endregion

        #region View
        // GET: Doctor
        public IActionResult Index()
        {
            return View(new DoctorViewModel());
        }

        public IActionResult DeleteDoctor(int doctorId)
        {
            _doctorService.DeleteDoctor(doctorId);

            return RedirectToAction("Index", "Doctor");
            //return View(model);
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult Details(DoctorViewModel model, int doctorId)
        {
            model.LoadData(doctorId);
            return View(model);
        }

        public IActionResult EditUpdate(DoctorViewModel model, int doctorId)
        {
            model.LoadData(doctorId);
            return View(model);
        }
        #endregion

        #region Add Doctor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDoctor(DoctorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _doctorService.AddDoctor(PrepareDoctorSubmissionModel(model));
            return RedirectToAction("Index", "Doctor");
            //return View(model);
        }
        #endregion

        #region Edit Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUpdate(DoctorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _doctorService.UpdateDoctor(PrepareDoctorUpdateSubmissionModel(model));
            return RedirectToAction("Index", "Doctor");
            //return View(model);
        }
        #endregion

        #region Private Methods
        private DoctorSubmissionModel PrepareDoctorSubmissionModel(DoctorViewModel model)
        {
            return new DoctorSubmissionModel
            {
                Doctor_FirstName = model.Doctor_FirstName,
                Doctor_LastName = model.Doctor_LastName,
                Doctor_NrPhone = model.Doctor_NrPhone,
                Doctor_Address = model.Doctor_Address
            };
        }

        private DoctorUpdateSubmissionModel PrepareDoctorUpdateSubmissionModel(DoctorViewModel model)
        {
            return new DoctorUpdateSubmissionModel
            {
                Id = model.Id,
                Doctor_FirstName = model.Doctor_FirstName,
                Doctor_LastName = model.Doctor_LastName,
                Doctor_NrPhone = model.Doctor_NrPhone,
                Doctor_Address = model.Doctor_Address
            };
        }
        #endregion
    }
}