using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using QuestionnaireMVC.Business.Interfaces;

namespace QuestionnaireMVC.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IQuestionService _questionService;
        private readonly ILogger _logger;

        public StatisticsController(IStatisticsService statisticsService, IQuestionService questionService, ILogger<StatisticsController> logger)
        {
            _statisticsService = statisticsService;
            _questionService = questionService;
            _logger = logger;
        }


        [Route("statistics")]
        public IActionResult Index()
        {

            try
            {
                var questions = _questionService.GetQuestions();
                _logger.LogInformation($"Getting All Questions ...");
                return View(questions);
            }catch(Exception e)
            {
                _logger.LogError($"Getting All Questions : {e.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        [Route("statistics/question/{id}")]
        public JsonResult GetNumberOfVotesPerOptionForQuestion(int id)
        {

            try
            {
                var question = _questionService.GetQuestionById(id);
                var statistics = _statisticsService.GetCountOptionsPerQuestionList(question.Result);
                _logger.LogInformation($"Generating Statistics ....");
                return Json(statistics);
            }catch(Exception e)
            {
                _logger.LogError($"Error in GetNumberOfVotesPerOptionForQuestion : Error while Getting data {e.Message}");
                return Json($"Error in GetNumberOfVotesPerOptionForQuestion : Error while Getting data {e.Message}");
            }
            
        }

        [Route("statistics/questionOptions/{id}")]
        public JsonResult GetQuestionOptions(int id)
        {
            try
            {

                _logger.LogInformation($"Get Question Options ....");
                return Json(_questionService.GetQuestionOptions(id));

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetQuestionOptions : Error while Getting data {e.Message}");
                return Json($"Error in GetQuestionOptions : Error while Getting data {e.Message}");
            }
        }
    }
}