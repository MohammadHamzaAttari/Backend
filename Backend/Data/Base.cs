using System.ComponentModel.DataAnnotations;

namespace Backend.Data
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; } 
    }
}
