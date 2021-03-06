using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.application.Interfaces
{
    public interface IOrdinance_SharedDbContext
    {
        DbSet<Ordinance> Ordinances { get; set; }

        int SaveChangesAsync();
    }
}
