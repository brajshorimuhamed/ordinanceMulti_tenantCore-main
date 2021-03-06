using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.application.Helpers
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static HttpContext Context => _httpContextAccessor.HttpContext;
    }
}
