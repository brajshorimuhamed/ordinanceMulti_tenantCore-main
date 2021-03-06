using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Ordinances
{
    public interface IOrdinanceService
    {
        Task AddOrdinance(OrdinanceSubmissionModel model);
        Task<Ordinance> GetById(int? id);
        Task<IList<Ordinance>> GetOrdinances();
    }
}
