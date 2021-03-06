using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
