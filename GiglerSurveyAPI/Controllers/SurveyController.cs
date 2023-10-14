using Microsoft.AspNetCore.Mvc;
using Survey.DTO;
using Survey.Services.Interface;

namespace GiglerSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ITblQuestionService _tblQuestionService;
        public SurveyController(ITblQuestionService tblQuestionService, IConfiguration configuration)
        {
            _tblQuestionService = tblQuestionService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            IEnumerable<TblQuestionDto> tblQuestionDtos = null;
            tblQuestionDtos = await _tblQuestionService.GetAllQuestions();
            return Ok(tblQuestionDtos);
        }
    }
}
