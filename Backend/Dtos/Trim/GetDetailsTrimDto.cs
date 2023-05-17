using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Trim
{
    public class GetDetailsTrimDto:BaseDto
    {
        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
    }
}
