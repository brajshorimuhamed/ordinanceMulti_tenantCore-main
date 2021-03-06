using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Doctors
{
    public interface IDoctorService
    {
        Task AddDoctor(DoctorSubmissionModel model);
        Task<IList<Doctor>> GetDoctors();
        Task<IList<Doctor>> GetDoctorsById(int doctorId);
        Task<bool> UpdateDoctor(DoctorUpdateSubmissionModel model);
        Task<bool> DeleteDoctor(int doctorId);
    }
}
