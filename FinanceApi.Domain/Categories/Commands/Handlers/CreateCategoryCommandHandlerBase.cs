using FinanceApi.Domain.Categories.Commands.Requests;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Categories.Commands.Handlers
{
    public abstract class CreateCategoryCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<CategoryEntity>, CreateCategoryRequest>
    {
    }
}
