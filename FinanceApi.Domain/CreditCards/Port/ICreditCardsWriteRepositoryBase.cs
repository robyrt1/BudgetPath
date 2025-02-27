﻿using FinanceApi.Domain.CreditCards.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Port
{
    public interface ICreditCardsWriteRepositoryBase
    {
        public Task<CreditCardEntity> create(CreateCreditCardRequest creditcard);
        public Task<CreditCardEntity> Update(UpdateCreditCardRequest request);

        public Task Delete(Guid Id);
    }
}
