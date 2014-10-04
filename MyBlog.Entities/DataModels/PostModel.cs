using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.DataModels
{
    public class PostModel
    {
        public int PostID { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string PostHeading { get; set; }
        public string SecondaryText { get; set; }
        public string Title { get; set; }
        public string PostDescription { get; set; }
        public string PostImage { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
