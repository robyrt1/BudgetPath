﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users.Port
{
    public interface IUserWriteRepositoryBase
    {
        Task<UserEntity>Create(UserEntity userEntity);
    }
}
