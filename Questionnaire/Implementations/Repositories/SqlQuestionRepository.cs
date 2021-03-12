using System.Collections.Generic;
using System.Linq;
using Questionnaire.Data;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Questionnaire.Implementations.Repositories
{
    public class SqlQuestionRepository : IQuestionRepository
    {
        private readonly QuestionnaireContext _context;

        public SqlQuestionRepository(QuestionnaireContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions.Include("Options");
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.Find(id);
        }
    }
}