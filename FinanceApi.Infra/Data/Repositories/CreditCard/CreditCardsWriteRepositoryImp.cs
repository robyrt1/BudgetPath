using Azure.Core;
using FinanceApi.Domain.CreditCard;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data.Repositories.CreditCard
{
    public class CreditCardsWriteRepositoryImp : ICreditCardsWriteRepositoryBase
    {
        private readonly AppDbContext _context;

        public CreditCardsWriteRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreditCardEntity> create(CreateCreditCardRequest creditcard)
        {
            var CreditCardNew = new CreditCardEntity()
            {
                Name = creditcard.Name,
                AccountId = creditcard.AccountId,
                Maturity = creditcard.Maturity,
                Closing = creditcard.Closing,
                Limit = creditcard.Limit ?? 0
            };
            await _context.CreditCard.AddAsync(CreditCardNew);
            await _context.SaveChangesAsync();

            return CreditCardNew;
        }


        public async Task<CreditCardEntity> Update(UpdateCreditCardRequest request)
        {
            var creditCardOrigin = await _context.CreditCard.SingleAsync(cc => cc.Id == request.Id);

            creditCardOrigin.Closing = request.Closing ?? creditCardOrigin.Closing;
            creditCardOrigin.AccountId = request.AccountId ?? creditCardOrigin.AccountId;
            creditCardOrigin.Name = request.Name ?? creditCardOrigin.Name;
            creditCardOrigin.Limit = request.Limit ?? creditCardOrigin.Limit;
            creditCardOrigin.Maturity = request.Maturity ?? creditCardOrigin.Maturity;

            await _context.SaveChangesAsync();
            return creditCardOrigin;
        }

        public async Task Delete(Guid Id)
        {
            var creditCardOrigin = await _context.CreditCard.SingleAsync(cc => cc.Id == Id);
            _context.Remove(creditCardOrigin);

            await _context.SaveChangesAsync();
        }
    }
}
