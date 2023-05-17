using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "You password must be greater than {2} and less than{1}",
            MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
