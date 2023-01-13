using System.ComponentModel.DataAnnotations;

namespace Scrubs.Domain.Entity {

    public class Register {

        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(50, ErrorMessage = "Имя должно быть короче 50 символов")]
        [MinLength(3, ErrorMessage = "Имя не должно быть короче 3 символов")]
        public string? Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Имя не должно быть короче 8 символов")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }

    }

}

