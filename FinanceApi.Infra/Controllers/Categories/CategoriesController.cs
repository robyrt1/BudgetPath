using FinanceApi.Domain.Categories.Queries.Handlers;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromServices] GetCategoriesQueryhandlerBase getCategoriesQueryhandler)
        {
            var categories = await getCategoriesQueryhandler.Handle();
            return Ok(categories);
        }
    }
}
