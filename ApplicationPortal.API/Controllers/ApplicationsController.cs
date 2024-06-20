using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationPortal.API.Controllers
{
    [ApiController]
    [Route("forms/{formId}/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IFormService _formService;

        public ApplicationsController(IFormService formService)
        {
            _formService = formService;
        }
        /// <summary>
        /// Submit an application for a saved application form
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="applicationDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddApplication(string formId, ApplicationDto applicationDto)
        {
            var application = await _formService.SubmitApplicationAsync(formId, applicationDto);
            return Ok(application);
        }
        /// <summary>
        /// Get details of a saved application
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetApplication(string formId, string applicationId)
        {
            var application = await _formService.GetApplicationAsync(formId, applicationId);
            return Ok(application);
        }
    }
}
