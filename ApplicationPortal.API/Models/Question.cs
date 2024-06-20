namespace ApplicationPortal.API.Models
{
    public class Question
    {
        public string id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public List<string>? Choices { get; set; }
    }
}
