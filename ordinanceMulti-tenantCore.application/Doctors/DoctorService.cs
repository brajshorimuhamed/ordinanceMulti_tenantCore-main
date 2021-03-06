using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IOrdinance_TenantDbContext _context;

        public DoctorService(ITenantDbContextProvider provider)
        {
            _context = provider?.Context ?? throw new ArgumentNullException(nameof(provider));
        }

        public async Task AddDoctor(DoctorSubmissionModel model)
        {
            var entity = model.ToEntity();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            await _context.Doctors.AddRangeAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctor(int doctorId)
        {
            var entity = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctorId);
            if (entity != null)
            {
                _context.Doctors.Remove(entity);
                return _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IList<Doctor>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<IList<Doctor>> GetDoctorsById(int doctorId)
        {
            return await _context.Doctors.Where(x => x.Id == doctorId).ToListAsync();
        }

        public async Task<bool> UpdateDoctor(DoctorUpdateSubmissionModel model)
        {
            var entity = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity != null)
            {
                entity.Id = model.Id;
                entity.Doctor_FirstName = model.Doctor_FirstName;
                entity.Doctor_LastName = model.Doctor_LastName;
                entity.Doctor_NrPhone = model.Doctor_NrPhone;
                entity.Doctor_Address = model.Doctor_Address;

                return _context.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
