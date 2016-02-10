using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSP.Services.Model
{
    public class BlogEntrySummary
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string PublishedDate { get; set; }
        public string CommentCount { get; set; }
        public string Comment { get; set; }
    }
}
