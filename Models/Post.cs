namespace EntityFramework.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string User { get; set; }
        public string UserImage { get; set; } = "http://via.placeholder.com/140x140";

        public int BlogId {get;set;}
        public Blog Blog{get;set;}

    }
}