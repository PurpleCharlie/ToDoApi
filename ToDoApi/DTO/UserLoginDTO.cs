using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTO
{
    public class UserAuthDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Password { get; set; }
    }
}
