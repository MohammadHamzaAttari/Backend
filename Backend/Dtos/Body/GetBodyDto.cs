using Backend.Dtos.Base;

namespace Backend.Dtos.Body
{
    public class GetBodyDto:BaseDto
    {
        
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
    }
}
