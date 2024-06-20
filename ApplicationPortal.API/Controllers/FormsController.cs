using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationPortal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }
        /// <summary>
        /// Save a new Form
        /// </summary>
        /// <param name="formDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] FormDto formDto)
        {
            var form = await _formService.CreateFormAsync(formDto);
            return Ok(form);
        }
        /// <summary>
        /// Get details of a form by its id
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        [HttpGet("{formId}")]
        public async Task<IActionResult> GetForm(string formId)
        {
            var form = await _formService.GetFormAsync(formId);
            return Ok(form);
        }
    }
}
