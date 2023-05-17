using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administration",
                    NormalizedName="AMINISTRATION"
                },
                new IdentityRole
                {
                    Name = "Dealer",
                    NormalizedName = "DEALER"
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER"
                }
                );
        }
    }
}
