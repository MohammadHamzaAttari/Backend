using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Body
{
    public class UpdateBodyDto:BaseDto
    {
        [Required]
        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }

        [NotMapped]
        public IFormFile? FileUpload { get; set; }
    }
}
