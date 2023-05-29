using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Comment
    {
        [Display(Name = " ID Комментария ")]
        [Key]
        public int Comment_Id { get; set; }

        [Display(Name = "Комментарий")]
        [StringLength (50, MinimumLength = 3)]
        [Required(ErrorMessage = "Введите  Комментарий")]      
        public string Commentaryi { get; set; } /*Комментарий*/

        [Display(Name = "Оценка")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть в диапазоне от 1 до 5")]
        [Required(ErrorMessage = "Введите значение Оценки")]
        public int Evaluation { get; set; }  /*Оценка*/

        [Display(Name = "ID Клиента ")]
        public int? IdClient { get; set; }
        [Display(Name = "ID Тура")]
        public int? IdTour { get; set; }
        [Display(Name = "ID Отеля")]
        public int? IdHotelя { get; set; }
        [Display(Name = "ID Авиарейса")]
        public int? IdFlingt { get; set; }





}
}
