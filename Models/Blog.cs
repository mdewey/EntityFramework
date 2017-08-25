using System;
using System.Collections.Generic;

namespace EntityFramework.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public string ImageUrl{get;set;} = "http://via.placeholder.com/242x200";

        public string Description {get;set;}
        public string Body{get;set;}

        public bool IsPublished {get;set;} = false;
        public DateTime PublishedDate {get;set;} = DateTime.Now;

        public IEnumerable<Post> Posts {get;set;} = new HashSet<Post>();

    }
}