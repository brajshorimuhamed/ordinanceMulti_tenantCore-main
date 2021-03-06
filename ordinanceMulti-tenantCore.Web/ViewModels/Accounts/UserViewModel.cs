using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.application.Ordinances;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.Web.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels.Accounts
{
    public class UserViewModel : BaseViewModel
    {
        #region Input
        public int OrdinanceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        public IList<Ordinance> Ordinances { get; set; } = new List<Ordinance>();

        
        public override async void Init()
        {
            Ordinances = await HttpContextHelper.Context.RequestServices.GetRequiredService<IOrdinanceService>().GetOrdinances();
        }
    }
}
