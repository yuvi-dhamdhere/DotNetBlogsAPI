using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomBlogsAPI.Model
{
    [Table("blogsCategory")]
    public class myCategoryEntity
    {
        [Key]
        [Required]
        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; } = string.Empty;
    }
}
