using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionnaire.Implementations.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;

namespace QuestionnaireAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IQuestionService _questionService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return Ok(_questionService.GetQuestions());
        }
    }
}