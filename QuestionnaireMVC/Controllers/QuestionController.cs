using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using QuestionnaireMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Controllers
{
    public class QuestionController : Controller
    {
        readonly IQuestionService _questionService;
        readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        readonly User user;
        public QuestionController(IQuestionService questionService, IAnswerService answerService, IUserService userService)
        {
            _questionService = questionService;
            _answerService = answerService;
            _userService = userService;
            user = new User
            {
                Id = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Email = "mrhazzoul@gmail.com",
                Name = "rhazzoul",
                Answers = new List<Answer>(),

        };
        }

        // GET: QuestionController
        public ActionResult Index()
        {
            var questions = _questionService.GetQuestions().ToList();
            CheckBoxListViewModel model = new CheckBoxListViewModel
            {
                questions = questions
            };
            return View(model);
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(Object[] obj)
        {

            var x = Request.Form.ToList();
            try
            {
                var i = 1;
                foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> entry in x)
                {
                    if(i < x.Count()) { 
                    var indexes = entry.Value.Select(x=>Int32.Parse(x)).ToArray();

                    Answer answer = _answerService.SubmitAnswer(Int32.Parse(entry.Key), user.Id, indexes);
                    _userService.AddAnswer(user, answer);
                    i++;
                    }
                }

                user.TimeOfCompletion = new DateTime((int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - user.Id);
                _userService.AddUser(user);
                return Json(user);
            }
            catch(Exception e)
            {
                
                return Json(e);
            }
        }

        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
