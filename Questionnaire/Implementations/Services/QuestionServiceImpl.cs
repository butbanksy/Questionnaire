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
    class QuestionServiceImpl : IQuestionService
    {

        private readonly IQuestionRepository _questionRepository;

        public QuestionServiceImpl(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _questionRepository.GetQuestions();
        }
        public Question GetQuestionById(int id)
        {
            return _questionRepository.GetQuestionById(id);
        }

        
    }
}
