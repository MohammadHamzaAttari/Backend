using Backend.Dtos.Company;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Model
{
    public class CreateModelDto
    {
        public string? Name { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        
    }
}
