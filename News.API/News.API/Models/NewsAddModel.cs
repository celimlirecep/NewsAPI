namespace News.API.Models
{
    public class NewsAddModel
    {
        public string NewsName { get; set; }
        public string NewsContent{ get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
