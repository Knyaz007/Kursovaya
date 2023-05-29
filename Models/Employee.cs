using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Employee
    {

        [Key]
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }

        [Display(Name = "Возраст")]
        public string? Position { get; set; } //Должность, занимаемая сотрудником в турфирме.

        [Display(Name = "ID")]
        public int Salary { get; set; } //Заработная плата сотрудника.


        [Display(Name = "Вступил в должность ")]
        public DateTime Hire_Date { get; set; } //Дата, когда сотрудник был принят Дата.

 


        [Required(ErrorMessage = "Введите электронную почту")]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Формат почты неправильный")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{1})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Формат номера неправильный")]
        //[RegularExpression(@"^\+?(\d[\d -. ]+)?(\([\d -. ]+\))?[\d-. ]+\d$", ErrorMessage = "Формат номера неправильный")]
        public string? Phone { get; set; }

        [DisplayName("Фото")]
        public string? Photo { get; set; }



    }
}
