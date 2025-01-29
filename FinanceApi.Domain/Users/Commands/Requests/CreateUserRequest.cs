using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users.Commands.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? FirebaseUid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
