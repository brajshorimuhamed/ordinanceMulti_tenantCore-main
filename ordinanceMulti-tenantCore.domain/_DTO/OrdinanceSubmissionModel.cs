using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain._DTO
{
    public class OrdinanceSubmissionModel
    {
        public string Ordinance_Name { get; set; }
        public string Sector { get; set; }
        public string Ordinance_Address { get; set; }

        public Ordinance ToEntity()
        {
            return new Ordinance
            {
                Ordinance_Name = Ordinance_Name,
                Sector = Sector,
                Ordinance_Address = Ordinance_Address
            };
        }
    }
}
