using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    public class Posts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }
        [DisplayName("UserID")]
        public int UserID { get; set; }
        
        [Required]
        [DisplayName("Post Header")]
        [MaxLength(250)]
        public string PostHeading { get; set; }
        
        [DisplayName("Post Secondary Text")]
        public string SecondaryText { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        [MaxLength(1500)]
        public string PostDescription { get; set; }

        [DisplayName("Image")]
        public string PostImage { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Date")]
        public DateTime CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int PostActive { get; set; }


    }
}

