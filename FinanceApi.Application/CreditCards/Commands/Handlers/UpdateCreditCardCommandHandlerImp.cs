using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.CreditCards.Commands.Handlers
{
    public class UpdateCreditCardCommandHandlerImp: UpdateCreditCardCommandHandlerBase
    {
        private ICommandRepositoryBase<CreditCardEntity> _creditCardsWriteRepository;
        private GetCreditCardsQueryHandlerBase _getCreditCardsQueryHandler;

        public UpdateCreditCardCommandHandlerImp(ICommandRepositoryBase<CreditCardEntity> creditCardsWriteRepository, GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler)
        {
            _creditCardsWriteRepository = creditCardsWriteRepository;
            _getCreditCardsQueryHandler = getCreditCardsQueryHandler;
        }

        public override async Task<ResponseWrapperBase<CommandHandlerCreditCardResponse>> Handle(UpdateCreditCardRequest command)
        {
            IQueryable<CreditCardEntity> creditCards = await _getCreditCardsQueryHandler.HandleAsync();
            CreditCardEntity creditCard = creditCards.FirstOrDefault(c => c.Id == command.Id);

            if (creditCard is null)
            {
                return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Conta não cadastrado."
                );
            }

            creditCard.Closing = command.Closing ?? creditCard.Closing;
            creditCard.AccountId = command.AccountId ?? creditCard.AccountId;
            creditCard.Name = command.Name ?? creditCard.Name;
            creditCard.Limit = command.Limit ?? creditCard.Limit;
            creditCard.Maturity = command.Maturity ?? creditCard.Maturity;

            await _creditCardsWriteRepository.UpdateAsync(creditCard);

            return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                  data: new CommandHandlerCreditCardResponse
                  {
                      Id = creditCard.Id,
                      AccountId = creditCard.AccountId,
                      Closing = creditCard.Closing,
                      Limit = creditCard.Limit,
                      Maturity = creditCard.Maturity,
                      Name = creditCard.Name
                  },
                  statusCode: (int)HttpStatusCode.OK,
                  message: "Sucesso"
                );
        }
    }
}
