using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Configs
{

    namespace API.Configs
    {
        public static class ErrorHandlingCustom
        {
            public static BadRequestObjectResult Handler(this ActionContext actionContext)
            {
                var errors = actionContext.ModelState
                           .Where(e => e.Value.Errors.Count > 0)
                           .Select(e => new
                           {
                               status = "Thất bại",
                               code = 400,
                               error = String.Format("Sai tham số {0}", e.Key.Contains(".")?e.Key.Split(".")[1]: e.Key)
                           }).FirstOrDefault();

                return new BadRequestObjectResult(errors);
            }
        }
    }

}
