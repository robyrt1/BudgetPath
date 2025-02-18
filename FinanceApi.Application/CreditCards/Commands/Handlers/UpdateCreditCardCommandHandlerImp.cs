using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.CreditCards.Port;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.CreditCards.Commands.Handlers
{
    public class UpdateCreditCardCommandHandlerImp: UpdateCreditCardCommandHandlerBase
    {
        private ICreditCardsWriteRepositoryBase _creditCardsWriteRepository;
        private GetCreditCardsQueryHandlerBase _getCreditCardsQueryHandler;
        public UpdateCreditCardCommandHandlerImp(ICreditCardsWriteRepositoryBase creditCardsWriteRepository, GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler)
        {
            _creditCardsWriteRepository = creditCardsWriteRepository;
            _getCreditCardsQueryHandler = getCreditCardsQueryHandler;
        }

        public override async Task<ResponseWrapperBase<CommandHandlerCreditCardResponse>> Handle(UpdateCreditCardRequest command)
        {
            var creditCards = await _getCreditCardsQueryHandler.HandleAsync();
            var shouldCreditCard = creditCards
                .SingleOrDefault(c => c.Id == command.Id);

            if (shouldCreditCard is null)
            {
                return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Conta não cadastrado."
                );
            }


            var created = await _creditCardsWriteRepository.Update(command);

            return new ResponseWrapper<CommandHandlerCreditCardResponse>(
                  data: new CommandHandlerCreditCardResponse
                  {
                      Id = created.Id,
                      AccountId = created.AccountId,
                      Closing = created.Closing,
                      Limit = created.Limit,
                      Maturity = created.Maturity,
                      Name = created.Name
                  },
                  statusCode: (int)HttpStatusCode.OK,
                  message: "Sucesso"
                );
        }
    }
}
