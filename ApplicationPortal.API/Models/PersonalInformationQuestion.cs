namespace ApplicationPortal.API.Models
{
    public class PersonalInformationQuestion
    {
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool PhoneNumber { get; set; }
        public bool Email { get; set; }
        public bool Nationality { get; set; }
        public bool BirthDate { get; set; }
        public bool Residence { get; set; }
        public bool Gender { get; set; }
        public bool IDNumber { get; set; }
        public List<Question> CustomQuestions { get; set; }
    }
}
