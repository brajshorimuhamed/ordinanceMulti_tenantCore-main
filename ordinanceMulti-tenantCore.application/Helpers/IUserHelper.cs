using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Helpers
{
    public interface IUserHelper
    {
        Task<string> GetOrdinanceId();
    }
}
