using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain._DTO
{
    public class DoctorSubmissionModel
    {
        public string Doctor_FirstName { get; set; }
        public string Doctor_LastName { get; set; }
        public int Doctor_NrPhone { get; set; }
        public string Doctor_Address { get; set; }

        public Doctor ToEntity()
        {
            return new Doctor
            {
                Doctor_FirstName = Doctor_FirstName,
                Doctor_LastName = Doctor_LastName,
                Doctor_NrPhone = Doctor_NrPhone,
                Doctor_Address = Doctor_Address
            };
        }
    }
}
