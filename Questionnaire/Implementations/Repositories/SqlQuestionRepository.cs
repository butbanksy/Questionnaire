using System.Collections.Generic;
using System.Linq;
using Questionnaire.Data;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;

namespace Questionnaire.Implementations.Repositories
{
    public class SqlQuestionRepository : IQuestionRepository
    {
        private readonly QuestionnaireContext _context;

        public SqlQuestionRepository(QuestionnaireContext context)
        {
            _context = context;
        }

        public SqlQuestionRepository()
        {
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions;
        }

        public Question GetQuestionById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}