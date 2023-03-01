using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Models
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }
        public string Method { get; set; }
        public string Date { get; set; }
        public decimal TotalPayment { get; set; }

        //1:1 relationship between payment and customer
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
}
