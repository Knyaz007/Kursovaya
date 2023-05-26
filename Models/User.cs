using System.ComponentModel;

namespace Kursovaay.Models
{
    public class User
    {

        public int UserId { get; set; } // Идентификатор пользователя
        public string Username { get; set; } // Имя пользователя
        public string Password { get; set; } // Пароль пользователя
        [DisplayName("Фото")]
        public string? PathPhoto { get; set; }

        public bool IsAdmin { get; set; } // Флаг, указывающий, является ли пользователь администратором


    }
}
