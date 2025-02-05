using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Shared.Http
{
    public class ResponseHelper
    {
        public static IActionResult CreateResponse(object? data, int statusCode = 200)
        {
            return new ObjectResult(new
            {
                status = statusCode == 200,
                details = data
            })
            {
                StatusCode = statusCode
            };
        }
    }
}
