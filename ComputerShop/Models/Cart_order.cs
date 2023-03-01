using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Cart_order
    {
        [Key]
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public int TotalAmount { get; set; }


        //1:N relationship between Cart_Order and Cart_Item
        public virtual ICollection<Cart_Item> Cart_Items { get; set; } = new List<Cart_Item>();

        //1:N relationship between Customer and Cart_Order
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
