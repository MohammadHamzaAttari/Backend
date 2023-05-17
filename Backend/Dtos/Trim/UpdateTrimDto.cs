using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Trim
{
    public class UpdateTrimDto:BaseDto
    {
        
        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
    }
}
