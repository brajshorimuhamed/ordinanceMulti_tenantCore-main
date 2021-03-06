using ordinanceMulti_tenantCore.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string Doctor_FirstName { get; set; }
        public string Doctor_LastName { get; set; }
        public int Doctor_NrPhone { get; set; }
        public string Doctor_Address { get; set; }
    }
}
