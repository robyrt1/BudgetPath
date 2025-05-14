using FinanceApi.Domain.Categories;
using FinanceApi.Domain.Categories.Commands.Handlers;
using FinanceApi.Domain.Categories.Commands.Requests;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Categories.Commands.Handlers
{
    public class CreateCategoryCommandHandlerImp: CreateCategoryCommandHandlerBase
    {
        private readonly ICommandRepositoryBase<CategoryEntity> _categoryWriteRepository;

        public CreateCategoryCommandHandlerImp(ICommandRepositoryBase<CategoryEntity> categoryWriteRepository) 
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public override async Task<ResponseWrapperBase<CategoryEntity>> Handle(CreateCategoryRequest command )
        {
            throw new NotImplementedException();
        }
    }
}
