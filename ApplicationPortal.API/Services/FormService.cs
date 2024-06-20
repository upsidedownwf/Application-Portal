using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Models;
using ApplicationPortal.API.Repositories;

namespace ApplicationPortal.API.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Form> CreateFormAsync(FormDto formDto)
        {
            var form = new Form
            {
                id = Guid.NewGuid().ToString(),
                PersonalInformation = new PersonalInformationQuestion
                {
                    FirstName = formDto.PersonalInformation.FirstName,
                    LastName = formDto.PersonalInformation.LastName,
                    Email = formDto.PersonalInformation.Email,
                    PhoneNumber = formDto.PersonalInformation.PhoneNumber,
                    Nationality = formDto.PersonalInformation.Nationality,
                    Gender = formDto.PersonalInformation.Gender,
                    BirthDate = formDto.PersonalInformation.BirthDate,
                    IDNumber = formDto.PersonalInformation.IDNumber,
                    Residence = formDto.PersonalInformation.Residence,
                    CustomQuestions = formDto.PersonalInformation.CustomQuestions?.Select(q => new Question
                    {
                        id = Guid.NewGuid().ToString(),
                        Type = q.Type,
                        Title = q.Title,
                        Choices = q.Choices
                    }).ToList()
                },
                AdditionalQuestions = formDto.AdditionalQuestions.Questions.Select(q => new Question
                {
                    id = Guid.NewGuid().ToString(),
                    Type = q.Type,
                    Title = q.Title,
                    Choices = q.Choices
                }).ToList()
            };

            await _formRepository.AddFormAsync(form);
            return form;
        }

        public async Task<Form> GetFormAsync(string formId)
        {
            return await _formRepository.GetFormAsync(formId);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync(string formId)
        {
            var questions = new List<Question>();
            var form = await _formRepository.GetFormAsync(formId);
            //if there are questions in the Personal Information section, add them to the list of all questions returned
            if (form != null && form.PersonalInformation.CustomQuestions != null && form.PersonalInformation.CustomQuestions.Any()) questions.AddRange(form.PersonalInformation.CustomQuestions);
            // add the list of question in the additional information section
            questions.AddRange(form?.AdditionalQuestions);
            return questions;
        }

        public async Task UpdateQuestionAsync(string formId, string questionId, QuestionDto questionDto)
        {
            var question = new Question
            {
                id = questionId,
                Type = questionDto.Type,
                Title = questionDto.Title,
                Choices = questionDto.Choices
            };

            var form = await GetFormAsync(formId);
            var questionToUpdate = default(Question);
            //check if the question for update is in the personal information section or the additional information section
            questionToUpdate = form.PersonalInformation.CustomQuestions?.FirstOrDefault(q => q.id == question.id);
            if (questionToUpdate == null) questionToUpdate = form.AdditionalQuestions?.FirstOrDefault(q => q.id == question.id);
            if (questionToUpdate != null)
            {
                questionToUpdate.Title = question.Title;
                questionToUpdate.Type = question.Type;
                questionToUpdate.Choices = question.Choices;

                await _formRepository.UpdateFormAsync(form);
            }
        }

        public async Task<Application> SubmitApplicationAsync(string formId, ApplicationDto applicationDto)
        {
            var application = new Application
            {
                id = Guid.NewGuid().ToString(),
                FormId = formId,
                PersonalInformation = new PersonalInformation
                {
                    FirstName = applicationDto.PersonalInformation.FirstName,
                    LastName = applicationDto.PersonalInformation.LastName,
                    PhoneNumber = applicationDto.PersonalInformation.PhoneNumber,
                    Email = applicationDto.PersonalInformation.Email,
                    BirthDate = applicationDto.PersonalInformation.BirthDate,
                    Residence = applicationDto.PersonalInformation.Residence,
                    Gender = applicationDto.PersonalInformation.Gender,
                    Nationality = applicationDto.PersonalInformation.Nationality,
                    IDNumber = applicationDto.PersonalInformation.IDNumber,
                    CustomQuestionsAnswers = applicationDto.PersonalInformation.CustomQuestionsAnswers?.Select(q => new Answer
                    {
                        Value = q.Value,
                        Other = q.Other,
                        QuestionId = q.QuestionId,
                    }).ToList(),
                },
                AdditionalAnswers = applicationDto.AdditionalAnswers.Select(q => new Answer
                {
                    Value = q.Value,
                    Other = q.Other,
                    QuestionId = q.QuestionId,
                }).ToList()
            };
            await _formRepository.AddApplicationAsync(application);
            return application;
        }

        public async Task<Application> GetApplicationAsync(string formId, string applicationId)
        {
            return await _formRepository.GetApplicationAsync(formId, applicationId);
        }
    }

}
