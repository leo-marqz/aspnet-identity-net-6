
using ASPNetIdentity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASPNetIdentity.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.UrlWebSite).IsRequired(false);
            builder.Property(x=>x.Country).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.CountryCode).HasMaxLength(10).IsRequired();
            builder.Property(x=>x.City).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Address).HasMaxLength(100).IsRequired(false);
            builder.Property(x=>x.DateOfBirth).IsRequired();
        }
    }
}