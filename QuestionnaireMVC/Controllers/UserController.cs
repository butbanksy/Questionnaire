using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Helpers;
using QuestionnaireMVC.Models;
using System;
using System.Collections.Generic;

namespace QuestionnaireMVC.Controllers
{

    public class UserController : Controller
    {
        private IUserService _serviceUser;
        private ILogger _logger;
        private readonly HttpContext _context;

        public UserController(IUserService serviceUser, IHttpContextAccessor contextAccessor, ILogger<UserController> logger)
        {
            _serviceUser = serviceUser;
            _context = contextAccessor.HttpContext;
            _logger = logger;
        }

        public ActionResult Index()
        {
            try
            {
                _logger.LogInformation($"Generating Statistics ....");
                return View(new User());

            }catch(Exception e)
            {
                _logger.LogError($"Error in User/Index {e.Message}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public ActionResult Index(User user)

        {
            try
            {
                user.GenerateUserId();
                user.Answers = new List<Answer>();
                // _serviceUser.AddUser(user);
                HttpContext.Session.SetComplexData("currentUser", user);
                _logger.LogInformation($"User/Index adding user to sessions ....");
                return RedirectToAction("Index", "Question");
            }catch(Exception e)
            {
                _logger.LogError($"Error while adding user to sessions User/Index  {e.Message}");
                return RedirectToAction("Error", "Home");
            }

        }




    }
}
