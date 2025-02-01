using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Interfaces
{
    public interface Input
    {
        string Name { get; }

    }

    public class UserInput : Input
    {
        public string Name { get; set; }
    }


    public interface ITokenService
    {
        string Generate(UserInput input);
    }
}
