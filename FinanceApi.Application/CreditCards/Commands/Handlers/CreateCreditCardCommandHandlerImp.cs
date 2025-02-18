using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.CreditCards.Port;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.CreditCards.Commands.Handlers
{
    public class CreateCreditCardCommandHandlerImp : CreateCreditCardCommandHandlerBase
    {
        private ICreditCardsWriteRepositoryBase _creditCardsWriteRepository;
        private GetCreditCardsQueryHandlerBase _getCreditCardsQueryHandler;
        public CreateCreditCardCommandHandlerImp(ICreditCardsWriteRepositoryBase creditCardsWriteRepository, GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler) {
            _creditCardsWriteRepository = creditCardsWriteRepository;
            _getCreditCardsQueryHandler = getCreditCardsQueryHandler;
        }

        public override async Task<ResponseWrapperBase<CreateCreditCardResponse>>  Handle(CreateCreditCardRequest command)
        {
            var creditCards = await _getCreditCardsQueryHandler.HandleAsync();
            var shouldCreditCard = creditCards
                .Where(c => c.Name.ToLower().Contains(command.Name.ToLower()) && c.AccountId == command.AccountId)
                .ToList();

            if (shouldCreditCard.Any())
            {
                return new ResponseWrapper<CreateCreditCardResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Já existe um cartão com esse nome para essa conta."
                );
            }


            var created = await _creditCardsWriteRepository.create(command);

            return new ResponseWrapper<CreateCreditCardResponse>(
                  data: new CreateCreditCardResponse
                  {
                      Id = created.Id,
                      AccountId = created.AccountId,
                      Closing = created.Closing,
                      Limit = created.Limit,
                      Maturity = created.Maturity,
                      Name = created.Name
                  },
                  statusCode: (int)HttpStatusCode.Created,
                  message: "Sucesso"
                );
        }
    }
}
