using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API_Parcial3.DAL.Entities
{
    public class Hotel : AuditBase
    {
        [Display(Name = "Hotel")] 
        [MaxLength(50, ErrorMessage = "Field {0} must have a maximum of {1} characters")] 
        [Required(ErrorMessage = "Field {0} is mandatory!")] 
        public String Name { get; set; }

        [Display(Name = "Address")]
        [MaxLength(40, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} mandatory!")]
        public String Address { get; set; }

        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} is mandatory!")]
        public String City { get; set; }

        [Display(Name = "Phone")]
        [MaxLength(25, ErrorMessage = "Field {0} must have a maximum of {1} characters")]
        public String? Phone { get; set; }

        [Display(Name = "Stars")]
        [Range(1, 5, ErrorMessage = "Stars must be in the range 1 to 5")]
        [Required(ErrorMessage = "Field {0} is mandatory!")]
        public int Stars { get; set; }






        [Display(Name = "Rooms")]
        //relation with Room
        public ICollection<Room>? Rooms { get; set; }





    }
}
