using System.ComponentModel.DataAnnotations;

namespace BlazorBasic.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        // Relationship with Products (N:M)
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
