using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Category
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        //1:N relationship between Product and category
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        //M:N relationship between Category and Customer
        public virtual ICollection<Customer> Customers{ get; set; } = new List<Customer>();
    }
}
