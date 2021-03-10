using System.Text.Json;
using System;
using System.Linq;
using Questionnaire.Implementations.Repositories;
using Questionnaire.Models;

namespace Questionnaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            JsonQuestionRepository json = new JsonQuestionRepository();

            var questions = json.GetQuestions();

            foreach (var question in questions)
            {
                Console.WriteLine($"{question.Id} : {question.Title}");
            }
        }
    }
}