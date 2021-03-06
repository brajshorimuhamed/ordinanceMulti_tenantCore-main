using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain._DTO
{
    public class InfermierSubmissionModel
    {
        public string Infermier_FirstName { get; set; }
        public string Infermier_LastName { get; set; }
        public int Infermier_NrPhone { get; set; }
        public string Infermier_Address { get; set; }

        public Infermier ToEntity()
        {
            return new Infermier
            {
                Infermier_FirstName = Infermier_FirstName,
                Infermier_LastName = Infermier_LastName,
                Infermier_NrPhone = Infermier_NrPhone,
                Infermier_Address = Infermier_Address
            };
        }
    }
}
