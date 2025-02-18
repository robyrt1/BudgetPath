using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Application.Shared.Wrappers
{
    public class ResponseWrapper<T> : ResponseWrapperBase<T>
    {
        public ResponseWrapper(T? data, int statusCode, string? message = null)
            : base(data, statusCode, message)
        {
        }
    }
}

