using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Cart_Item
    {
        [Key]
        public int CartItemID { get; set; }
        public string CartItemName { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }


        

    }
}
