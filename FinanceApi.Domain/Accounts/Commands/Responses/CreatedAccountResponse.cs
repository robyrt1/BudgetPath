using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Responses
{
    public class CreatedAccountResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public Decimal? Balance { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
