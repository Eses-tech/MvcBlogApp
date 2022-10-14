using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Explanation { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Approval { get; set; }
        public bool HomePage { get; set; }

        public int CategoryId { get; set; }
        


    }
}