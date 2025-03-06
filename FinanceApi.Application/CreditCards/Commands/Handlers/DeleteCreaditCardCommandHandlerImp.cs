using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.CreditCards.Commands.Handlers
{
    public class DeleteCreaditCardCommandHandlerImp : DeleteCreditCardCommandHandlerBase
    {
        private ICommandRepositoryBase<CreditCardEntity> _creditCardsWriteRepository;
        private GetCreditCardsQueryHandlerBase _getCreditCardsQueryHandler;
        public DeleteCreaditCardCommandHandlerImp(ICommandRepositoryBase<CreditCardEntity> creditCardsWriteRepository, GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler)
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

            await _creditCardsWriteRepository.DeleteAsync(command.Id);

            return  new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.NoContent,
                    message: "Deletado com sucesso"
                );
        }
    }
}
