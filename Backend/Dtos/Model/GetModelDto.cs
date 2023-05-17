using Backend.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Model
{
    public class GetModelDto:BaseDto
    {
       public string? Name { get; set; }
       

    }
}