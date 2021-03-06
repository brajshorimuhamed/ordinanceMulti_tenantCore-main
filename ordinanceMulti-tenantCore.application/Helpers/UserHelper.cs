using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.application.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;

        public UserHelper(IUserStore<User> userStore, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
        {
            _userManager = new UserManager<User>(userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger);
        }

        public async Task<string> GetOrdinanceId()
        {
            var user = await _userManager.GetUserAsync(HttpContextHelper.Context.User);
            var claims = await _userManager.GetClaimsAsync(user);
            return claims.FirstOrDefault(x => x.Type == "Ordinance").Value;
        }
    }
}
