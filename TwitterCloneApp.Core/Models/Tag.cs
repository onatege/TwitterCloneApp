namespace TwitterCloneApp.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
    }
}
