using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }

        [StringLength (50, MinimumLength = 3)]
        [Required(ErrorMessage = "Введите  Комментарий")]      
        public string Commentaryi { get; set; } /*Комментарий*/

       
        [Range(1, 5, ErrorMessage = "Оценка должна быть в диапазоне от 1 до 5")]
        [Required(ErrorMessage = "Введите значение Оценки")]
        public int Evaluation { get; set; }  /*Оценка*/

        public int? IdClient { get; set; }
        public int? IdTour { get; set; }
        public int? IdHotelя { get; set; }
        public int? IdFlingt { get; set; }



    //    public DateTime Дата { get; set; }       /* представляет дату, когда был оставлен отзыв.*/
    //    public bool Подтвержден { get; set; }  /*был ли отзыв подтвержден администратором или модератором.*/

    //    public int Comment_Id { get; set; }
    //    public string Commentary { get; set; } // Комментарий
    //    public int Evaluation { get; set; } // Оценка

    //    private int? idClient;
    //    public int? IdClient
    //    {
    //        get => idClient;
    //        set
    //        {
    //            if (string.IsNullOrEmpty(Commentary))
    //                idClient = value;
    //            else
    //                throw new InvalidOperationException("Access to 'IdClient' is not allowed when 'Commentary' is already set.");
    //        }
    //    }

    //    private int? idTour;
    //    public int? IdTour
    //    {
    //        get => idTour;
    //        set
    //        {
    //            if (string.IsNullOrEmpty(Commentary))
    //                idTour = value;
    //            else
    //                throw new InvalidOperationException("Access to 'IdTour' is not allowed when 'Commentary' is already set.");
    //        }
    //    }

    //    private int? idHotel;
    //    public int? IdHotel
    //    {
    //        get => idHotel;
    //        set
    //        {
    //            if (string.IsNullOrEmpty(Commentary))
    //                idHotel = value;
    //            else
    //                throw new InvalidOperationException("Access to 'IdHotel' is not allowed when 'Commentary' is already set.");
    //        }
    //    }

    //    private int? idFlight;
    //    public int? IdFlight
    //    {
    //        get => idFlight;
    //        set
    //        {
    //            if (string.IsNullOrEmpty(Commentary))
    //                idFlight = value;
    //            else
    //                throw new InvalidOperationException("Access to 'IdFlight' is not allowed when 'Commentary' is already set.");
    //        }
    //    }

    //    public DateTime Date { get; set; } // представляет дату, когда был оставлен отзыв.
    //    public bool Confirmed { get; set; } // был ли отзыв подтвержден администратором или модератором.
    //}



}
}
