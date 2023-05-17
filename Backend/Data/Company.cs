using System.ComponentModel.DataAnnotations;

namespace Backend.Data
{
    public class Company:Base
    {

        public string? Name { get; set; }   
        public virtual ICollection<Model>? Models { get; set; }
    }
}
