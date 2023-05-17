using System.ComponentModel.DataAnnotations;
using Backend.Dtos.Base;
using Backend.Dtos.Model;

namespace Backend.Dtos.Company
{
    public class GetCompanyDto:BaseDto
    {
        
        [Required]
        public string? Name { get; set; }
       
    }
   
}
