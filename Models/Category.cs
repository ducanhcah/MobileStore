using System.ComponentModel.DataAnnotations;

namespace MobileStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [StringLength(100)]
        public required string Name { get; set; }

        public string? Icon { get; set; } // Bootstrap icon class or image url

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
