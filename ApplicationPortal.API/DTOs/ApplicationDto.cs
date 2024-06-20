namespace ApplicationPortal.API.DTOs
{
    public class ApplicationDto
    {
        public PersonalInformationDto PersonalInformation { get; set; }
        public List<AnswerDto> AdditionalAnswers { get; set; }
    }

}
