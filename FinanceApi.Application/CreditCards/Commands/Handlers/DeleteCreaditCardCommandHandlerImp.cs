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
    public class DeleteCreaditCardCommandHandlerImp : DeleteCreaditCardCommandHandlerBase
    {
        private ICreditCardsWriteRepositoryBase _creditCardsWriteRepository;
        private GetCreditCardsQueryHandlerBase _getCreditCardsQueryHandler;
        public DeleteCreaditCardCommandHandlerImp(ICreditCardsWriteRepositoryBase creditCardsWriteRepository, GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler)
        {
            _creditCardsWriteRepository = creditCardsWriteRepository;
            _getCreditCardsQueryHandler = getCreditCardsQueryHandler;
        }

        public override async Task<ResponseWrapperBase<object>> Handle(DeleteCreditCardRequest command)
        {
            var creditCards = await _getCreditCardsQueryHandler.HandleAsync();
            var shouldCreditCard = creditCards
                .SingleOrDefault(c => c.Id == command.Id);

            if (shouldCreditCard is null)
            {
                return new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Conta não cadastrado."
                );
            }

            await _creditCardsWriteRepository.Delete(command.Id);

            return  new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.NoContent,
                    message: "Deletado com sucesso"
                );
        }
    }
}
