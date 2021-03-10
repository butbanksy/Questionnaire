using System.Text.Json;
using System;
using Questionnaire.Helpers.StringHelpers;
using Questionnaire.Interfaces.Services;
using System.Linq;
using Questionnaire.Implementations.Repositories;
using Questionnaire.Models;

namespace Questionnaire
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "";
            string email = "";

            //services
            IQuestionService questionServices;


            //Get Services


            Console.WriteLine("-------------------Welcome to the survey-------------------");
            Console.WriteLine("The survet has {NumQuestions} Question");
            Console.WriteLine(
                "Each question has many options, You can answer the question by taping the number of the option.");
            Console.WriteLine("Once saved, you can't change your answer");
            Console.WriteLine("\n\n\n**Personal informations ");

            //get user's name
            do
            {
                Console.WriteLine("Please enter your name :");
                username = Console.ReadLine();
            } while (username.isNullOrEmpty());


            //get user's name
            do
            {
                Console.WriteLine("Please enter your Email :");
                email = Console.ReadLine();
            } while (email.isNullOrEmpty() || !email.isValidMail());


            //creating the user
            User user = new User(username, email);


            JsonQuestionRepository json = new JsonQuestionRepository();

            var questions = json.GetQuestions();
            Console.WriteLine("Tape any key to start the Survey");
            Console.ReadLine();
            Console.Clear();

            foreach (var question in questions)
            {
                Console.WriteLine($"{question.Id} : {question.Title}");
            }

            var questionById = json.GetQuestionById(3);
            Console.WriteLine(questionById.ToString());
        }
    }
}