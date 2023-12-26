namespace SimpleLearn.API.Models.Domain
{
    public class BlogPost
    {
        public Guid ID  { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content   { get; set; }
        public string FeaturedImageURL { get; set; }

        public DateTime PublishDate { get; set; }
        public bool IsVisible { get; set; }
    }
}
