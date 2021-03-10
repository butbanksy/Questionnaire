using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Helpers.DIHelpers;
using Questionnaire.Helpers.GeneralHelpers;
using Questionnaire.Helpers.StringHelpers;
using Questionnaire.Implementations.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;

namespace Questionnaire
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string username = "";
            string email = "";
            int answerIndex;

            bool reEnter = false;

            //register services
            //register dependecies
            var serviceProvider = DIHelpers.getServiceProvider();


            //get service instance
            IQuestionService questionServices = serviceProvider.GetService<IQuestionService>();
            IUserService userService = serviceProvider.GetService<IUserService>();
            IAnswerService answerService = serviceProvider.GetService<IAnswerService>();
            IStatisticsService statisticsService = serviceProvider.GetService<IStatisticsService>();

            var questions = questionServices.GetQuestions();


            //Get Services

            Console.WriteLine($"The survet has {questions.Count()} Question");
            Console.WriteLine("Each question has many options, You can answer the question by taping the number of the option.");
            Console.WriteLine("Once saved, you can't change your answer");
            Console.WriteLine("\n\n\n**Personal informations ");


            do
            {


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
                Console.WriteLine("Tap enter to start the Survey");
                Console.ReadLine();
                Console.Clear();

                //Showing questions
                questions.ToList().ForEach(q =>
                {
                    Console.WriteLine(q);


                    // to check if the answer is valide
                    bool state;
                    do
                    {
                        Console.Write("Answer (In range of options) :");
                        state = int.TryParse(Console.ReadLine(), out answerIndex);
                    } while (state == false || answerIndex > q.Options.Count() || answerIndex < 1);

                    Answer answer = answerService.GetAnswer(new int[] { answerIndex }, q);

                    answer.UserId = user.Id;
                    userService.AddAnswer(user, answer);

                });

                userService.AddUser(user);


                Console.WriteLine("Answer Saved !!");

                Console.WriteLine("Tap enter to view the statistics the Survey");
                Console.ReadLine();
                Console.Clear();


                


                Console.WriteLine("Tap [e] to enter a new user, any other key to quit and show stats :");
                var s = Console.ReadLine();
                reEnter = s == "e";


                Console.Clear();

            } while (reEnter);


            statisticsService.ShowStates();



        }
    }
}
