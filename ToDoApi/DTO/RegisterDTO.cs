using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int Password { get; set; }
    }
}
