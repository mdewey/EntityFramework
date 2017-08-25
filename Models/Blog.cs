using System;

namespace EntityFramework.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }

        public DateTime PublishedDate {get;set;}
    }
}