using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Repository.Context
{
    public class MelhoresPraticasContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<UserAccount> UserAccounts { get; set; }

        public MelhoresPraticasContext(DbContextOptions<MelhoresPraticasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserPhoneMap());
            builder.ApplyConfiguration(new UserAddressMap());
            builder.ApplyConfiguration(new UserAccountMap());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

    }
}
