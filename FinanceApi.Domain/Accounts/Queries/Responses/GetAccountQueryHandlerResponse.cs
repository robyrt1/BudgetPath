using FinanceApi.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Queries.Responses
{
    public class GetAccountQueryHandlerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserMapper? User { get; set; } 
    }

    public class UserMapper
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
