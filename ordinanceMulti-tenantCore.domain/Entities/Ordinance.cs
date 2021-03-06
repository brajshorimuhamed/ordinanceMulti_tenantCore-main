using ordinanceMulti_tenantCore.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain.Entities
{
    public class Ordinance : BaseEntity
    {
        public Ordinance()
        {
            Users = new HashSet<User>();
        }

        public string Ordinance_Name { get; set; }
        public string Sector { get; set; }
        public string Ordinance_Address { get; set; }
        public Guid TenantId { get; set; } = Guid.NewGuid();

        public ICollection<User> Users { get; set; }
    }
}
