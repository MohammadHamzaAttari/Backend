using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data
{
    public class Trim : Base
    {

        public string? Name { get; set; }
        [ForeignKey(nameof(ModelId))]
        public int ModelId { get; set; }
        public virtual Model? Model { get; set; }
    }
}
