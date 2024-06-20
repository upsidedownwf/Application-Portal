namespace ApplicationPortal.API.DTOs
{
    public class AnswerDto
    {
        public string QuestionId { get; set; }
        public List<string> Value { get; set; }
        public bool? Other { get; set; }
    }

}
