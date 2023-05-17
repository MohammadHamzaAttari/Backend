using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Backend.Dtos.Trim
{
    public class CreateTrimDto
    {
        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }

    }
}
