using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUKulinarium_API.Data.Models
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("UserProfile")]
        public Guid ProfileId { get; set; }
        [Required]
        public string CardProvider { get; set; }
        [Required]
        [CreditCard]
        public string CardNumber { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        public int SecurityCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}