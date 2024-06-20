using ApplicationPortal.API.Models;
using Microsoft.Azure.Cosmos;

namespace ApplicationPortal.API.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly Container _container;

        public FormRepository(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddFormAsync(Form form)
        {
            await _container.CreateItemAsync(form, new PartitionKey(form.id));
        }

        public async Task<Form> GetFormAsync(string formId)
        {
            try
            {
                ItemResponse<Form> response = await _container.ReadItemAsync<Form>(formId, new PartitionKey(formId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateFormAsync(Form form)
        {
                await _container.UpsertItemAsync(form, new PartitionKey(form.id));
        }

        public async Task AddApplicationAsync(Application application)
        {
            await _container.CreateItemAsync(application, new PartitionKey(application.id));
        }

        public async Task<Application> GetApplicationAsync(string formId, string applicationId)
        {
            try
            {
                ItemResponse<Application> response = await _container.ReadItemAsync<Application>(applicationId, new PartitionKey(applicationId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }

}
