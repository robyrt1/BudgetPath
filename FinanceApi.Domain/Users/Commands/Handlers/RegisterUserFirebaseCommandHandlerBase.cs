﻿using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Users.Commands.Requests;
using FinanceApi.Domain.Users.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users.Commands.Handlers
{
    public abstract class RegisterUserFirebaseCommandHandlerBase : HandlerBaseShared<RegisterUserFirebaseResponse, RegisterUserFirebaseRequest>
    {
    }
}
