using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Honda"
                },
                new Company
                {
                    Id = 2,
                    Name = "Toyota"
                },
                new Company
                {
                    Id = 3,
                    Name = "Ferry"
                }
                );
        }
    }
}
