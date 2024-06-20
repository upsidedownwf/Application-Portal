namespace ApplicationPortal.API.Models
{
    public class Application
    {
        public string id { get; set; }
        public string FormId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public List<Answer> AdditionalAnswers { get; set; }
    }
}
