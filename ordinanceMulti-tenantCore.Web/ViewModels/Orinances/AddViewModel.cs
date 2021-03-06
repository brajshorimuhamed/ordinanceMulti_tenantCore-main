using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels.Orinances
{
    public class AddViewModel : IValidatableObject
    {
        public string Ordinance_Name { get; set; }
        public string Sector { get; set; }
        public string Ordinance_Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Ordinance_Name))
                yield return new ValidationResult("Write ordinance name", new[] { "Ordinance_Name" });

            if (string.IsNullOrEmpty(Sector))
                yield return new ValidationResult("Write sector ordinance", new[] { "Sector" });

            if (string.IsNullOrEmpty(Ordinance_Address))
                yield return new ValidationResult("Write ordinance address", new[] { "Ordinance_Address" });

            yield return ValidationResult.Success;
        }
    }
}
