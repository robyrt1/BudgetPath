using FinanceApi.Domain.Debts;
using FinanceApi.Domain.Debts.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Debts.Queries.Handlers
{
    public class FindDebtsQueryHandlerImp : FindDebtsQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<DebtsEntity> _debtsRepository;

        public FindDebtsQueryHandlerImp(IQueriesRepositoryBase<DebtsEntity> debtsRepository)
        {
            _debtsRepository = debtsRepository;
        }

        public override IQueryable<DebtsEntity> Handle()
        {
            return _debtsRepository.GetAll()
                .AsNoTracking()
                .Include(c => c.CreditCard)
                .Include(a => a.Account)
                .Include(c => c.Category)
                     .ThenInclude(di => di.Group);
        }

        public override Task<IQueryable<DebtsEntity>> HandleAsync()
        {
            return _debtsRepository.GetAllAsync();
        }
    }
}
