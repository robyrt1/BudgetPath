using FinanceApi.Domain.Categories.Queries.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.OData.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class CategoriesODataController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get([FromServices] GetCategoriesQueryhandlerBase getCategoriesQueryhandler)
        {
            var categories = await getCategoriesQueryhandler.Handle();
            return Ok(categories);
        }
    }
}
