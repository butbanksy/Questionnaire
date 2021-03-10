using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Implementations.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}
