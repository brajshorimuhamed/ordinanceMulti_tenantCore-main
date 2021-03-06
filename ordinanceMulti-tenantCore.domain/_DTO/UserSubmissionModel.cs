using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.domain._DTO
{
    public class UserSubmissionModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int OrdinanceID { get; set; }

        public User ToEntity()
        {
            return new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                EmailConfirmed = true,
                UserName = Email,
                OrdinanceId = OrdinanceID
            };
        }
    }
}
