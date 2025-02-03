using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users.Queries.Requests
{
    public class GetUserByFirebaseUidRequest
    {
        public string FirebaseUid { get; set; }
    }
}
