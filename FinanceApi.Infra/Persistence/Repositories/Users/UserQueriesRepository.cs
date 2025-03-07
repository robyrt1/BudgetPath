﻿using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Persistence.Repositories.Users
{
    public class UserQueriesRepository : IUserQueriesRepositoryBase
    {
        private readonly AppDbContext _context;

        public UserQueriesRepository(AppDbContext context) { 
            _context = context;
        }


        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.Users.Where(user =>user.EmailLower == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetByFirebaseUid(string firebaseUid)
        {
            return await _context.Users.Where(user => user.FirebaseUid == firebaseUid).FirstOrDefaultAsync();
        }
    }
}
