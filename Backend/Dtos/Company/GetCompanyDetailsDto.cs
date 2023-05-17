using Backend.Dtos.Base;
using Backend.Dtos.Model;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Company
{
    public class GetCompanyDetailsDto:BaseDto
    {
            [Required]
            public string? Name { get; set; }
            public virtual ICollection<GetModelDto>? Models { get; set; }
        
    }
}
