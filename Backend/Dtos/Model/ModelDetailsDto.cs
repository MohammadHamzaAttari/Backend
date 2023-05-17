using Backend.Dtos.Base;
using Backend.Dtos.Body;
using Backend.Dtos.Trim;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Model
{
    public class ModelDetailsDto:BaseDto
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public virtual ICollection<GetBodyDto>? Bodies { get; set; }
        public virtual ICollection<GetTrimDto>? Trims { get; set; }
    }
}
