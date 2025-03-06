using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FinanceApi.Application.CreditCards.Commands.Handlers
{
    public class CreateCreditCardCommandHandlerImp : CreateCreditCardCommandHandlerBase
    {
        private ICommandRepositoryBase<CreditCardEntity> _creditCardsWriteRepository;
        private readonly IQueriesRepositoryBase<CreditCardEntity> _getCreditCardsQueryHandler;

        public CreateCreditCardCommandHandlerImp(ICommandRepositoryBase<CreditCardEntity> creditCardsWriteRepository, IQueriesRepositoryBase<CreditCardEntity> getCreditCardsQueryHandler) {
            _creditCardsWriteRepository = creditCardsWriteRepository;
            _getCreditCardsQueryHandler = getCreditCardsQueryHandler;
        }

        public override async Task<ResponseWrapperBase<CommandHandlerCreditCardResponse>>  Handle(CreateCreditCardRequest command)
        {
            var creditCard = await _getCreditCardsQueryHandler.Find(
                    c => c.Name.ToLower().Contains(command.Name.ToLower()) && c.AccountId == command.AccountId)
                .ToListAsync();

            if (creditCard.Any())
            {
                return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Já existe um cartão com esse nome para essa conta."
                );
            }

            var CreditCardNew = new CreditCardEntity()
            {
                Name = command.Name,
                AccountId = command.AccountId,
                Maturity = command.Maturity,
                Closing = command.Closing,
                Limit = command.Limit ?? 0
            };

            await _creditCardsWriteRepository.AddAsync(CreditCardNew);

            return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                  data: new CommandHandlerCreditCardResponse
                  {
                      Id = CreditCardNew.Id,
                      AccountId = CreditCardNew.AccountId,
                      Closing = CreditCardNew.Closing,
                      Limit = CreditCardNew.Limit,
                      Maturity = CreditCardNew.Maturity,
                      Name = CreditCardNew.Name
                  },
                  statusCode: (int)HttpStatusCode.Created,
                  message: "Sucesso"
                );
        }
    }
}
