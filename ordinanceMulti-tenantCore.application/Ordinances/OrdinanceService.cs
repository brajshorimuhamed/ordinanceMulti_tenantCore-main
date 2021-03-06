using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Ordinances
{
    public class OrdinanceService : IOrdinanceService
    {
        private readonly IOrdinance_SharedDbContext _context;

        public OrdinanceService(IOrdinance_SharedDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddOrdinance(OrdinanceSubmissionModel model)
        {
            var entity = model.ToEntity();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            await _context.Ordinances.AddRangeAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task<Ordinance> GetById(int? id)
        {
            return await _context.Ordinances.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Ordinance>> GetOrdinances()
        {
            return await _context.Ordinances.ToListAsync();
        }
    }
}
