using ordinanceMulti_tenantCore.domain._DTO;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Infermiers
{
    public interface IInfermierService
    {
        Task AddInfermier(InfermierSubmissionModel model);
        Task<IList<Infermier>> GetInfermiers();
        Task<IList<Infermier>> GetInfermiersById(int infermierId);
        Task<bool> UpdateInfermier(InfermierUpdateSubmissionModel model);
        Task<bool> DeleteInfermier(int infermierId);
    }
}
