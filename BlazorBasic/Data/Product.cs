using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorBasic.Locales;


namespace BlazorBasic.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameRequired")]
        public string Name { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // Relationship with Store (1:N)
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        // Relationship with Categories (N:M)
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
