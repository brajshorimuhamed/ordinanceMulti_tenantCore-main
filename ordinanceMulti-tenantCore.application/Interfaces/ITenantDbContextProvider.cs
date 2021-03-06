using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.application.Interfaces
{
    public interface ITenantDbContextProvider
    {
        IOrdinance_TenantDbContext Context { get; }
    }
}
