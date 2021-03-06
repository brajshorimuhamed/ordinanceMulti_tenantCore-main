using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels.Accounts
{
    public class LoginViewModel : IValidatableObject
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
                yield return new ValidationResult("Please write your email.", new[] { "email" });
            if (string.IsNullOrEmpty(Password))
                yield return new ValidationResult("Please write your password.", new[] { "password" });
            yield return ValidationResult.Success;
        }
    }
}
