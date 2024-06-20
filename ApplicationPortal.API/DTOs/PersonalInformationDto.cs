namespace ApplicationPortal.API.DTOs
{
    public class PersonalInformationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Residence { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }
        public List<AnswerDto>? CustomQuestionsAnswers { get; set; }
    }

}
