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

        IQuestionRepository questionRepository;
        public IEnumerable<Question> GetQuestions()
        {
            return questionRepository.GetQuestions();
        }
        public Question GetQuestionById(int id)
        {
            return questionRepository.GetQuestionById(id);
        }

        
    }
}
