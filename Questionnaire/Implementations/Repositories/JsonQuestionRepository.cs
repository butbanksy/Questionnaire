using Questionnaire.Helpers;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Questionnaire.Implementations.Repositories
{
    public class JsonQuestionRepository : IQuestionRepository
    {
        private readonly IEnumerable<Question> _questions;

        public JsonQuestionRepository()
        {
            _questions = DataHelper<Question>.LoadJson();
        }

        public Question GetQuestionById(int id)
        {
            return _questions.First(question => question.Id == id);
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _questions;
        }
    }
}