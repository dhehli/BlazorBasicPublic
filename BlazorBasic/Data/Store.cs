using System.ComponentModel.DataAnnotations;

namespace BlazorBasic.Data
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        // One-to-Many Relationship with Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}