using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public int StockLevel { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductColor { get; set; }
        public string Supplier { get; set; }
        public string specifications { get; set; }

        //1:N relationship between Product and Cart_Item
        public virtual ICollection<Cart_Item> Cart_Items { get; set; } = new List<Cart_Item>();

        //M:N relationship between Product and Customer
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    }
}
