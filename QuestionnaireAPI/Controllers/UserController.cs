using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionnaireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetUsers());
        }
        
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.GetUsers().First(u => u.Id == id);
        }



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.AddUser(user);
        }

        

        
    }
}
