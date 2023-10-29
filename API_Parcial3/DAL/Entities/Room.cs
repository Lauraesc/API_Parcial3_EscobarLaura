using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace API_Parcial3.DAL.Entities
{
    public class Room : AuditBase
    {
        [Display(Name = "Number")]
        [MaxLength(3, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} is mandatory!")]
        public String Number { get; set; }

        [Display(Name = "Guests limit")]
        [Range(1, 6, ErrorMessage = "Guests must be in the range 1 to 6")]
        [Required(ErrorMessage = "Field {0} is mandatory!")]
        public int MaxGuests { get; set; }

        [Display(Name = "Availability")]
        [Required(ErrorMessage = "Field {0} is mandatory")]
        public bool Availability { get; set; }



        [Display(Name = "Hotel")]
        public Hotel? Hotel { get; set; } 

        [Display(Name = "Id Hotel")]
        public Guid HotelId { get; set; } //FK


    }
}
