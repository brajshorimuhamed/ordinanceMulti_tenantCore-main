using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinanceMulti_tenantCore.Web.ViewModels.Base
{
    public class BaseViewModel
    {
        protected bool initialized;

        protected BaseViewModel()
        {
            Init();
        }

        public virtual void Init()
        {
            initialized = true;
        }
    }
}
