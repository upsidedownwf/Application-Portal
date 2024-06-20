namespace ApplicationPortal.API.DTOs
{
    public class QuestionDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public List<string>? Choices { get; set; }
    }

}
