using Microsoft.AspNetCore.Mvc;
using Radiologi___Backend.Models;
using Radiologi___Backend.Storage;

namespace Radiologi___Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private ITestDB db = new TestDB();

        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Classes/{classId}", Name = "GetTestsByClassId")]
        public List<Questionare> GetTestsByClassId(string classId)
        {
            List<Questionare> questionares = db.GetTestsByClassId(classId);

            return questionares;
        }

        [HttpGet("{testId}", Name = "GetTestByTestId")]
        public Questionare GetTestByTestId(string testId)
        {
            Questionare questionare = db.GetTestByTestId(testId);

            return questionare;
        }
        [HttpPost]
        public void CreateTest(Questionare questionare)
        {
            db.CreateTest(questionare);
        }
        //[HttpPost("Temp", Name = "SaveAnswers")]
        //public void SaveAnswers(AnsweredTest answeredTest)
        //{
        //    db.SaveAnswers(answeredTest);
        //}
        [HttpPost("Answered", Name = "SaveAnswers")]
        public IActionResult SaveAnswers([FromBody] AnsweredTest answeredTest)
        {
            _logger.LogInformation("SaveAnswers called with data: {@AnsweredTest}", answeredTest);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state: {@ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            db.SaveAnswers(answeredTest);
            return Ok();
        }
    }
}
