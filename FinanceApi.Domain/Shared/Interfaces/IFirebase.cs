using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Interfaces
{
    public abstract class IFirebase
    {
        public virtual Task<string> VerifyGoogleTokenAsync(string idToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> VerifyGoogleTokenAsync(string idToken)
        {
            throw new NotImplementedException();
        }
    }
}
