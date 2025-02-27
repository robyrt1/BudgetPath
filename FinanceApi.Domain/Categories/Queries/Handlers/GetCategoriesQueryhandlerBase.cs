﻿using FinanceApi.Domain.Categories.Queries.Responses;
using FinanceApi.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Categories.Queries.Handlers
{
    public class GetCategoriesQueryhandlerBase : HandlerBaseShared<IQueryable<CategoryEntity>, object>
    {
        public virtual IQueryable<CategoryEntity> Handle()
        {
            throw new NotImplementedException("This method is not implemented.");
        }
    }
}
