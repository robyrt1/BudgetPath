using FinanceApi.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }

        private IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration,DbContextOptions<AppDbContext> options) : base(options) {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var typeDatabase = "AZURE_SQL_CONNECTIONSTRING";
            var conectionString = _configuration.GetConnectionString(typeDatabase);
            options.UseSqlServer(conectionString);
        }
    }
}
