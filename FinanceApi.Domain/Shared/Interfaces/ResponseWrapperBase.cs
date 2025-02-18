using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Interfaces
{
    public abstract class ResponseWrapperBase<T>
    {
        public bool Status { get; private set; }
        public int StatusCode { get; set; }
        public T? Details { get; set; }
        public string? Message { get; set; }

        public ResponseWrapperBase(T? data, int statusCode, string? message = null)
        {
            Status = statusCode >= 200 && statusCode < 300;
            StatusCode = statusCode;
            Details = data;
            Message = message ?? (Status ? "Success" : "Error");
        }
    }
}
