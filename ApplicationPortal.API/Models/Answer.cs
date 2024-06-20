namespace ApplicationPortal.API.Models
{
    public  class Answer
    {
        public string QuestionId { get; set; }
        public List<string> Value { get; set; }
        public bool? Other { get; set; }
    }
}
