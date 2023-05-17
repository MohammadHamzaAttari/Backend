using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configuration
{
    public class ModelsConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
                new Model
                {
                    Id = 1,
                    Name = "Accord"
                    //Description= "Adaptive Cruise Control: Adaptive Cruise Control (ACC) with Low-Speed Follow"
                    ,
                    CompanyId = 1
                },
                 new Model
                 {
                     Id = 2,
                     Name = "Civic HatchBack Sport Touring",
                     //Description = "Collision Mitigation Braking System (CMBS) + Forward Collision Warning (FCW) and Cross Traffic Monitor"

                     CompanyId = 1
                 },
                  new Model
                  {
                      Id = 3,
                      Name = "City 1.2LS MT",
                      //Description = "2 rear Speakers & 4 Tweeters Internet Package 10GB/Month for 1 Year"

                      CompanyId = 1
                  }
                );
        }
    }
}
