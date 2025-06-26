using System.ComponentModel.DataAnnotations;

namespace Think_Digitally_week01.Models
{
    public class Product : BaseEntity
    {
        
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}
