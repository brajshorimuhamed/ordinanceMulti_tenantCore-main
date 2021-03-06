using ordinanceMulti_tenantCore.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain.Entities
{
    public class Infermier : BaseEntity
    {
        public string Infermier_FirstName { get; set; }
        public string Infermier_LastName { get; set; }
        public int Infermier_NrPhone { get; set; }
        public string Infermier_Address { get; set; }
    }
}
