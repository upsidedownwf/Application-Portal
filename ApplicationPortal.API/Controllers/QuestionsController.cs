using ApplicationPortal.API.DTOs;
using ApplicationPortal.API.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationPortal.API.Controllers
{
    [ApiController]
    [Route("forms/{formId}/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IFormService _formService;

        public QuestionsController(IFormService formService)
        {
            _formService = formService;
        }
        /// <summary>
        /// Get all questions from both sections of an application form i.e Personal Information and Additional Questions
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions(string formId)
        {
            var questions = await _formService.GetAllQuestionsAsync(formId);
            return Ok(questions);
        }
        /// <summary>
        /// Update a question by its id
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="questionId"></param>
        /// <param name="questionDto"></param>
        /// <returns></returns>
        [HttpPut("{questionId}")]
        public async Task<IActionResult> UpdateQuestion(string formId, string questionId, QuestionDto questionDto)
        {
            await _formService.UpdateQuestionAsync(formId, questionId, questionDto);
            return Ok();
        }
    }
}
