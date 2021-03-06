using ordinanceMulti_tenantCore.domain._DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Users
{
    public interface IUserService
    {
        Task AddUser(UserSubmissionModel model);
    }
}
