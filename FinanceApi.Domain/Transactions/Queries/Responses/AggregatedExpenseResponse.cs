using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Transactions.Queries.Responses
{
    public class AggregatedExpenseResponse
    {
        public string? Account { get; set; }
        public string Period { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
