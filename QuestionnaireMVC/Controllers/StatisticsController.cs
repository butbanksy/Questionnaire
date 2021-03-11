using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Interfaces.Services;

namespace QuestionnaireMVC.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionRepository _questionRepository;

        public StatisticsController(IStatisticsService statisticsService, IQuestionRepository questionRepository,
            IQuestionService questionService)
        {
            _statisticsService = statisticsService;
            _questionRepository = questionRepository;
            _questionService = questionService;
        }


        [Route("statistics")]
        public IActionResult Index()
        {
            var questions = _questionService.GetQuestions();
            return View(questions);
        }

        [Route("statistics/question/{id}")]
        public JsonResult GetNumberOfVotesPerOptionForQuestion(int id)
        {
            var question = _questionRepository.GetQuestionById(id);

            var statistics = _statisticsService.GetCountOptionsPerQuestionList(question);
            return Json(statistics);
        }

        [Route("statistics/questionOptions/{id}")]
        public JsonResult GetQuestionOptions(int id)
        {
            return Json(_questionService.GetQuestionOptions(id));
        }
    }
}