using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Helpers.DIHelpers;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Controllers
{

    public class UserController : Controller
    {
        private IUserService _serviceUser;

        public UserController(IUserService serviceUser)
        {
            _serviceUser = serviceUser;
        }

        public ActionResult Index()

        {
            
            return View(new User());
        }
        [HttpPost]
        public ActionResult Index(User user)

        {

            user.GenerateUserId();
           // _serviceUser.AddUser(user);

            return RedirectToAction("/Questions",user);
        }




    }
}
