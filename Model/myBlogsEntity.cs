using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomBlogsAPI.Model
{
    [Table("Blogs")]
    public class myBlogsEntity
    {
        [Key]
        [Required]
        public int blogId { get; set; }

        //[Required]
        //public string blogName { get; set; } = string.Empty;
        [Required]
        public string blogTitle { get; set; } = string.Empty;
        public string blogDescription { get; set; } = string.Empty;
        //public string blogAuthor { get; set; } = string.Empty;
        public string blogContent { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
        public bool IsFeatured { get; set; } = default;
        public int categoryId { get; set; }
        public myCategoryEntity? category { get; set; }


    }
}
