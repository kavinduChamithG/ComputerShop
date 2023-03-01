using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Tracking
    {
        [Key]
        public string TrackingID { get; set; }
        public string TrackingStatus { get; set; }
        public string Curier_Name { get; set; }

        //1:N relationship between Cart_Order and Tracking
        public virtual ICollection<Cart_order> Cart_Orders { get; set; } = new List<Cart_order>();
    }
}
