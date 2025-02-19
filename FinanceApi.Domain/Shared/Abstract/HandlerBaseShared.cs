using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Abstract
{
    public abstract class HandlerBaseShared<OutPut, Input>
    {
        public virtual Task<OutPut> Handle(Input command)
        {
            throw new NotImplementedException("This method is not implemented.");
        }

        public virtual Task<OutPut> Handle(Input command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("This method is not implemented.");
        }
        public virtual Task<OutPut> Handle()
        {
            throw new NotImplementedException("This method is not implemented.");
        }


    }
}
