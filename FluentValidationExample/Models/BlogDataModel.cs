using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationExample.Models
{
    [Table("Tbl_blog")]
    public class BlogDataModel
    {
        [Key]
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
