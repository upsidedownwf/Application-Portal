using ApplicationPortal.API.Models;

namespace ApplicationPortal.API.Repositories
{
    public interface IFormRepository
    {
        Task AddFormAsync(Form form);
        Task<Form> GetFormAsync(string formId);
        Task UpdateFormAsync(Form form);
        Task AddApplicationAsync(Application application);
        Task<Application> GetApplicationAsync(string formId, string applicationId);
    }

}
