using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Interfaces
{
    public interface ICryptHash
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
