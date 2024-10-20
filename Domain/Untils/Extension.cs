using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Untils
{
    public static class Extension
    {
        public static Guid GetId(this IHttpContextAccessor httpContext)
        {
			try
			{

                var id = httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.PrimarySid);

                return Guid.Parse(id);
            }
			catch (Exception)
			{
               return Guid.Empty;
			}
        }
    }
}
