using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUKulinarium_API.Data.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }
        public string OrderDetails { get; set; }
        public int DeliveryTime { get; set; }
        [Phone]
        public string CourierPhone { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}