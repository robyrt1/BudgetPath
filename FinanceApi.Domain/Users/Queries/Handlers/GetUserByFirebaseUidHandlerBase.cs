using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Users.Queries.Requests;
using FinanceApi.Domain.Users.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users.Queries.Handlers
{
    public abstract class GetUserByFirebaseUidHandlerBase : HandlerBaseShared<GetUserByFirebaseUidResponse, GetUserByFirebaseUidRequest>
    {
    }
}
