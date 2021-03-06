using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.domain.Entities
{
    public class User : IdentityUser<string>
    {
        public int? OrdinanceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> userManager)
        {
            var authenticationType = "Put authentication type Here";

            var userIdentity = new ClaimsIdentity(await userManager.GetClaimsAsync(this), authenticationType);

            return userIdentity;
        }
    }
}
