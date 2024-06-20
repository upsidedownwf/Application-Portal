using ApplicationPortal.API.Models;

namespace ApplicationPortal.API.DTOs
{
    public class FormDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PersonalInformationQuestionDto PersonalInformation { get; set; }
        public AdditionalQuestionsDto? AdditionalQuestions { get; set; }
    }

}
