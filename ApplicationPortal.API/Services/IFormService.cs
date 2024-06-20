using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Models;

namespace ApplicationPortal.API.Services
{
    public interface IFormService
    {
        Task<Form> CreateFormAsync(FormDto formDto);
        Task<Form> GetFormAsync(string formId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync(string formId);
        Task UpdateQuestionAsync(string formId, string questionId, QuestionDto questionDto);
        Task<Application> SubmitApplicationAsync(string formId, ApplicationDto applicationDto);
        Task<Application> GetApplicationAsync(string formId, string applicationId);
    }

}
