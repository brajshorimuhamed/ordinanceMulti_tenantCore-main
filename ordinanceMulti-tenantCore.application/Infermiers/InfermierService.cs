using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Infermiers
{
    public class InfermierService : IInfermierService
    {
        private readonly IOrdinance_TenantDbContext _context;

        public InfermierService(ITenantDbContextProvider provider)
        {
            _context = provider?.Context ?? throw new ArgumentNullException(nameof(provider));
        }

        public async Task AddInfermier(InfermierSubmissionModel model)
        {
            var entity = model.ToEntity();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            await _context.Infermiers.AddRangeAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteInfermier(int infermierId)
        {
            var entity = await _context.Infermiers.FirstOrDefaultAsync(x => x.Id == infermierId);
            if (entity != null)
            {
                _context.Infermiers.Remove(entity);
                return _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IList<Infermier>> GetInfermiers()
        {
            return await _context.Infermiers.ToListAsync();
        }

        public async Task<IList<Infermier>> GetInfermiersById(int infermierId)
        {
            return await _context.Infermiers.Where(x => x.Id == infermierId).ToListAsync();
        }

        public async Task<bool> UpdateInfermier(InfermierUpdateSubmissionModel model)
        {
            var entity = await _context.Infermiers.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity != null)
            {
                entity.Id = model.Id;
                entity.Infermier_FirstName = model.Infermier_FirstName;
                entity.Infermier_LastName = model.Infermier_LastName;
                entity.Infermier_NrPhone = model.Infermier_NrPhone;
                entity.Infermier_Address = model.Infermier_Address;

                return _context.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
