using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;


        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return Ok(_questionService.GetQuestions());
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            return Ok(_questionService.GetQuestionById(id));
        }

        // POST api/<QuestionController>
        /*[HttpGet("options/{id}")]
        public ActionResult<IEnumerable<Option>> Get(int id)
        {
            return Ok(_questionService.GetQuestionOptions(id));
        }*/

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
