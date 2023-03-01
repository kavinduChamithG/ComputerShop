using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }

        //1:1 relationship between Customer and Payment
        public virtual Payment Payment{ get; set; }

        //M:N relationship between Product and Customer
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        //M:N relationship between Category and Customer
        public virtual ICollection<Category> Categories  { get; set; } = new List<Category>();

    }
}
