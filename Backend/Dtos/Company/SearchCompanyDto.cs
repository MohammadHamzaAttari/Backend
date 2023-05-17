using Backend.Dtos.Base;
using Backend.Dtos.Model;

namespace Backend.Dtos.Company
{
    public class SearchCompanyDto:BaseDto
    {
        public string? Name { get; set; }
        public virtual ICollection<SearchModelDto>? Models { get; set; }
    }
}
