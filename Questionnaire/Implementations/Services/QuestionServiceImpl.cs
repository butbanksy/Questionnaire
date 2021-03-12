using Questionnaire.Data;
using Questionnaire.Helpers;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Implementations.Services
{
    public class QuestionServiceImpl : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private QuestionnaireContext _questionnaireContext;

        public QuestionServiceImpl(IQuestionRepository questionRepository, QuestionnaireContext questionnaireContext)
        {
            this._questionRepository = questionRepository;
            _questionnaireContext = questionnaireContext;
        }

        
        /*
         public void init()
        {
            var questions = DataHelper<Question>.LoadJson();
            _questionnaireContext.Questions.Add(questions.ToList()[0]);
            _questionnaireContext.SaveChanges();

        }
        */

        public IEnumerable<Question> GetQuestions()
        {
           // init();
            return _questionRepository.GetQuestions();
        }

        public Question GetQuestionById(int id)
        {
            return _questionRepository.GetQuestionById(id);
        }

        public IEnumerable<Option> GetQuestionOptions(int id)
        {
            var question = GetQuestionById(id);
            return question.Options;
        }
    }
}