using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.application.Infermiers;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.Web.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels
{
    public class InfermierViewModel : BaseViewModel
    {
        #region Properties
        public IList<Infermier> Infermiers { get; set; }
        #endregion

        #region Input
        public int Id { get; set; }
        public string Infermier_FirstName { get; set; }
        public string Infermier_LastName { get; set; }
        public int Infermier_NrPhone { get; set; }
        public string Infermier_Address { get; set; }
        #endregion

        #region Init
        public override async void Init()
        {
            if (initialized) return;
            Infermiers = await HttpContextHelper.Context.RequestServices.GetRequiredService<IInfermierService>().GetInfermiers();
            base.Init();
        }
        #endregion

        #region Load Data
        public void LoadData(int infermierId)
        {
            try
            {
                var infermier = Infermiers.FirstOrDefault(x => x.Id == infermierId);
                Id = infermier.Id;
                Infermier_FirstName = infermier.Infermier_FirstName;
                Infermier_LastName = infermier.Infermier_LastName;
                Infermier_NrPhone = infermier.Infermier_NrPhone;
                Infermier_Address = infermier.Infermier_Address;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
