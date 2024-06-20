namespace ApplicationPortal.API.Models
{
    public class Form
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PersonalInformationQuestion PersonalInformation { get; set; }
        public List<Question> AdditionalQuestions { get; set; }
    }
}
