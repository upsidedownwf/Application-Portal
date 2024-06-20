using Moq;
using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Models;
using ApplicationPortal.API.Repositories;
using ApplicationPortal.API.Services;

namespace ApplicationPortal.API.Tests
{
    public class FormServiceTests
    {
        private readonly Mock<IFormRepository> _mockFormRepository;
        private readonly FormService _formService;

        public FormServiceTests()
        {
            _mockFormRepository = new Mock<IFormRepository>();
            _formService = new FormService(_mockFormRepository.Object);
        }

        [Fact]
        public async Task CreateFormAsync_ShouldCreateAndReturnForm()
        {
            // Arrange
            var formDto = new FormDto
            {
                PersonalInformation = new PersonalInformationQuestionDto
                {
                    FirstName = true,
                    LastName = true,
                    Email = true,
                    PhoneNumber = true,
                    CustomQuestions = new List<QuestionDto>
                    {
                        new QuestionDto { Type = "Paragraph", Title = "Describe yourself" }
                    }
                },
                AdditionalQuestions = new AdditionalQuestionsDto
                {
                    Questions = new List<QuestionDto>
                    {
                        new QuestionDto { Type = "YesNo", Title = "Have you worked here before?" }
                    }
                }
            };

            // Act
            var form = await _formService.CreateFormAsync(formDto);

            // Assert
            Assert.NotNull(form);
            Assert.True(form.PersonalInformation.FirstName);
            Assert.True(form.PersonalInformation.LastName);
            Assert.True(form.PersonalInformation.Email);
            Assert.True(form.PersonalInformation.PhoneNumber);
            Assert.False(form.PersonalInformation.Nationality);
            Assert.False(form.PersonalInformation.IDNumber);
            Assert.False(form.PersonalInformation.Gender);
            Assert.False(form.PersonalInformation.Residence);
            Assert.Single(form.PersonalInformation.CustomQuestions);
            Assert.Single(form.AdditionalQuestions);
            _mockFormRepository.Verify(repo => repo.AddFormAsync(It.IsAny<Form>()), Times.Once);
        }

        [Fact]
        public async Task GetFormAsync_ShouldReturnForm()
        {
            // Arrange
            var formId = "form-id";
            var form = new Form
            {
                id = formId,
                PersonalInformation = new PersonalInformationQuestion
                {
                    FirstName = true,
                    LastName = true,
                    Email = true,
                    PhoneNumber = true
                }
            };
            _mockFormRepository.Setup(repo => repo.GetFormAsync(formId)).ReturnsAsync(form);

            // Act
            var result = await _formService.GetFormAsync(formId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(formId, result.id);
            Assert.True(form.PersonalInformation.FirstName);
            Assert.True(form.PersonalInformation.LastName);
            Assert.True(form.PersonalInformation.Email);
            Assert.True(form.PersonalInformation.PhoneNumber);
            Assert.False(form.PersonalInformation.Nationality);
            Assert.False(form.PersonalInformation.IDNumber);
            Assert.False(form.PersonalInformation.Gender);
            Assert.False(form.PersonalInformation.Residence);
            _mockFormRepository.Verify(repo => repo.GetFormAsync(formId), Times.Once);
        }

        [Fact]
        public async Task GetAllQuestionsAsync_ShouldReturnAllQuestions()
        {
            // Arrange
            var formId = "form-id";
            var form = new Form
            {
                id = formId,
                PersonalInformation = new PersonalInformationQuestion
                {
                    CustomQuestions = new List<Question>
                    {
                        new Question { id = "q1", Type = "Paragraph", Title = "Describe yourself" }
                    }
                },
                AdditionalQuestions = new List<Question>
                {
                    new Question { id = "q2", Type = "YesNo", Title = "Have you worked here before?" }
                }
            };
            _mockFormRepository.Setup(repo => repo.GetFormAsync(formId)).ReturnsAsync(form);

            // Act
            var questions = await _formService.GetAllQuestionsAsync(formId);

            // Assert
            Assert.Equal(2, questions.Count());
            _mockFormRepository.Verify(repo => repo.GetFormAsync(formId), Times.Once);
        }

        [Fact]
        public async Task UpdateQuestionAsync_ShouldUpdateQuestion()
        {
            // Arrange
            var formId = "form-id";
            var questionId = "q1";
            var questionDto = new QuestionDto { Type = "Paragraph", Title = "Updated Question", Choices = null };
            var form = new Form
            {
                id = formId,
                PersonalInformation = new PersonalInformationQuestion
                {
                    CustomQuestions = new List<Question>
                    {
                        new Question { id = questionId, Type = "Paragraph", Title = "Original Question" }
                    }
                },
                AdditionalQuestions = new List<Question>()
            };
            _mockFormRepository.Setup(repo => repo.GetFormAsync(formId)).ReturnsAsync(form);

            // Act
            await _formService.UpdateQuestionAsync(formId, questionId, questionDto);

            // Assert
            Assert.Equal("Updated Question", form.PersonalInformation.CustomQuestions.First().Title);
            _mockFormRepository.Verify(repo => repo.UpdateFormAsync(form), Times.Once);
        }

        [Fact]
        public async Task SubmitApplicationAsync_ShouldCreateAndReturnApplication()
        {
            // Arrange
            var formId = "form-id";
            var applicationDto = new ApplicationDto
            {
                PersonalInformation = new PersonalInformationDto
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Email = "john.doe@example.com"
                },
                AdditionalAnswers = new List<AnswerDto>
                {
                    new AnswerDto { Value = new List<string>{"Yes" }, QuestionId = "q1" }
                }
            };

            // Act
            var application = await _formService.SubmitApplicationAsync(formId, applicationDto);

            // Assert
            Assert.NotNull(application);
            Assert.Equal("John", application.PersonalInformation.FirstName);
            Assert.Single(application.AdditionalAnswers);
            _mockFormRepository.Verify(repo => repo.AddApplicationAsync(It.IsAny<Application>()), Times.Once);
        }

        [Fact]
        public async Task GetApplicationAsync_ShouldReturnApplication()
        {
            // Arrange
            var formId = "form-id";
            var applicationId = "app-id";
            var application = new Application
            {
                id = applicationId,
                PersonalInformation = new PersonalInformation
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };
            _mockFormRepository.Setup(repo => repo.GetApplicationAsync(formId, applicationId)).ReturnsAsync(application);

            // Act
            var result = await _formService.GetApplicationAsync(formId, applicationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(applicationId, result.id);
            Assert.Equal("John", result.PersonalInformation.FirstName);
            _mockFormRepository.Verify(repo => repo.GetApplicationAsync(formId, applicationId), Times.Once);
        }
    }
}
