using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Helpers.DIHelpers;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Controllers
{

    public class UserController : Controller
    {
        private IUserService _serviceUser;
        private readonly HttpContext _context;

        public UserController(IUserService serviceUser, IHttpContextAccessor contextAccessor)
        {
            _serviceUser = serviceUser;
            _context = contextAccessor.HttpContext;
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
            var str = JsonSerializer.Serialize<User>(user);
            _context.Session.SetString("currentUser",str);
            return RedirectToAction("Index","Statistics");
        }




    }
}
