using Backend.Dtos.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Dtos.Body
{
    public class CreateBodyDto
    {
        [Required]
        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
       
        [NotMapped]
        public IFormFile? FileUpload { get; set; }
    }
}
