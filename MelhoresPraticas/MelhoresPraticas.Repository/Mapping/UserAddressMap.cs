using MelhoresPraticas.Domain.Account.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Repository.Mapping
{
    public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddress");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Complement).IsRequired();
            builder.Property(x => x.Neiborhood).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.ZipCode).IsRequired();

        }
    }
}
