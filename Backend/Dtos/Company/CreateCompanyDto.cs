
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Company
{
    public class CreateCompanyDto
    {
        [Required]
        public string? Name { get; set; }
    
    }
}
