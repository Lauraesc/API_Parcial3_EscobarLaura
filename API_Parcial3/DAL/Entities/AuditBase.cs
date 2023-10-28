using System.ComponentModel.DataAnnotations;

namespace API_Parcial3.DAL.Entities
{
    public class AuditBase
    {

        [Key] 
        [Required] 
        public Guid Id { get; set; } //this isn't nulleable bc it's a PK
        public DateTime? CreatedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }  
    }
}
