using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        //[StringLength(8, ErrorMessage = "You must specify password at least 8")]
        public string Password { get; set; }
    }
}