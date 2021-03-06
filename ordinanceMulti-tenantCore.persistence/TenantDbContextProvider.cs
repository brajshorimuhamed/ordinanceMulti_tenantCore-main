using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence
{
    public class TenantDbContextProvider : ITenantDbContextProvider
    {
        public IOrdinance_TenantDbContext Context { get; }
        
        public TenantDbContextProvider(DbContextOptions<Ordinance_TenantDbContext> options)
        {
            var ordinanceId = HttpContextHelper.Context.RequestServices.GetRequiredService<IUserHelper>()
                .GetOrdinanceId().Result;

            options.ContextType.Name.Replace("#TENANT#", ordinanceId ?? string.Empty);

            Context = new Ordinance_TenantDbContext(options);
        }
    }
}