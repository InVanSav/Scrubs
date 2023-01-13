using System;
using System.ComponentModel.DataAnnotations;

namespace Scrubs.Domain.Entity {

    public class Login {

        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(50, ErrorMessage = "Имя должно быть короче 50 символов")]
        [MinLength(3, ErrorMessage = "Имя не должно быть короче 3 символов")]
        public string? Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

    }
}

