using Microsoft.Extensions.DependencyInjection;
using ordinanceMulti_tenantCore.application.Doctors;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.Web.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels
{
    public class DoctorViewModel : BaseViewModel
    {
        #region Properties
        public IEnumerable<Doctor> Doctors { get; set; }
        #endregion

        #region Input
        public int Id { get; set; }
        public string Doctor_FirstName { get; set; }
        public string Doctor_LastName { get; set; }
        public int Doctor_NrPhone { get; set; }
        public string Doctor_Address { get; set; }
        #endregion
        
        #region Init
        public override void Init()
        {
            if (initialized) return;
            Doctors = HttpContextHelper.Context.RequestServices.GetRequiredService<IDoctorService>().GetDoctors().Result;
            base.Init();
        }
        #endregion

        #region Load Data
        public void LoadData(int doctorId)
        {
            try
            {
                var doctor = Doctors.FirstOrDefault(x => x.Id == doctorId);
                Id = doctor.Id;
                Doctor_FirstName = doctor.Doctor_FirstName;
                Doctor_LastName = doctor.Doctor_LastName;
                Doctor_NrPhone = doctor.Doctor_NrPhone;
                Doctor_Address = doctor.Doctor_Address;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
