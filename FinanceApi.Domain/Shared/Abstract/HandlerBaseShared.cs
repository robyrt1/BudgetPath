using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Abstract
{
    public abstract class HandlerBaseShared<OutPut, Input>
    {
        public abstract Task<OutPut> Handle(Input command);
        public virtual Task<OutPut> Handle()
        {
            throw new NotImplementedException("This method is not implemented.");
        }
    }
}
