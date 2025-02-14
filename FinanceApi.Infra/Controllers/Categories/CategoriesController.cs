using FinanceApi.Domain.Categories.Queries.Handlers;
using FinanceApi.Domain.Categories.Queries.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Controllers.Categories
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Categories")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetCategories([FromServices] GetCategoriesQueryhandlerBase getCategoriesQueryhandler)
        //{
        //    var categories = await getCategoriesQueryhandler.Handle();
        //    return Ok(categories);
        //}

        //[HttpGet("ByUser")]
        //public async Task<IActionResult> GetCategoriesByUser([FromQuery] GetCategoriesByUserQueryhandlerRequest request, [FromServices] GetCategoriesByUserQueryhandlerBase getCategoriesByUserQueryhandler)
        //{
        //    var categories = await getCategoriesByUserQueryhandler.Handle(request);
        //    return Ok(categories);
        //}
    }
}
