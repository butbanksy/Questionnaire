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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var questionsJson = File.ReadAllText($"../../../Resources/questions.json");

            _questions = JsonSerializer.Deserialize<IEnumerable<Question>>(questionsJson, options);
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