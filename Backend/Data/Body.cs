using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data
{
    public class Body:Base
    {
        
        public string? Name { get; set; }
            
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }    
        public virtual Model? Model { get; set; }

        [NotMapped]
        public IFormFile? FileUpload { get; set; }
    }
}
