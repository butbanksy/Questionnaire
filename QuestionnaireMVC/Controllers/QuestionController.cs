﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Helpers;
using QuestionnaireMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionnaireMVC.Controllers
{
    public class QuestionController : Controller
    {
        readonly IQuestionService _questionService;
        readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public QuestionController(IQuestionService questionService, IAnswerService answerService,
            IUserService userService, ILogger<QuestionController> logger)
        {
            _questionService = questionService;
            _answerService = answerService;
            _userService = userService;
            _logger = logger;
        }

        // GET: QuestionController
        public ActionResult Index()
        {
            _logger.LogInformation($"Question Index page");

            try
            {
                var questions = _questionService.GetQuestions().Result.ToList();
                _logger.LogInformation($"Questions index : Get all questions ...");
                CheckBoxListViewModel model = new CheckBoxListViewModel
                {
                    questions = questions
                };
                return View(model);
            }
            catch(Exception e)
            {
                _logger.LogError($"Questions index : get questions " +
                    $"\n{e.Message}");

                return RedirectToAction("Error", "Home");
            }

            
            
        }

        //// GET: QuestionController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: QuestionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Create(Object[] obj)
        {
            User user = HttpContext.Session.GetComplexData<User>("currentUser");
            _logger.LogInformation($"Question getCurrentUser {user.Name}");
            var x = Request.Form.ToList();
            try
            {
                var i = 1;
                foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> entry in x)
                {
                    if (i < x.Count())
                    {
                        var indexes = entry.Value.Select(x => Int32.Parse(x)).ToArray();

                        Answer answer = _answerService.SubmitAnswer(Int32.Parse(entry.Key), user.Id, indexes).Result;
                        _userService.AddAnswer(user, answer);
                        _logger.LogInformation($"Add answer to user {user.Name} {answer}");
                        i++;
                    }
                }

                user.TimeOfCompletion =
                    new DateTime((int) new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - user.Id);
                _userService.AddUser(user);
                _logger.LogInformation($"Add User {user.Name}");
                return RedirectToAction("Index", "Statistics");
            }
            catch (Exception e)
            {
                _logger.LogError($"Add new {e.Message}");
                return RedirectToAction("Error", "Home");
            }
        }

        //// GET: QuestionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: QuestionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: QuestionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: QuestionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}