using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;

namespace Questionnaire.Implementations.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionService _questionService;

        public StatisticsService(IUserRepository userRepository, IQuestionService questionService)
        {
            _userRepository = userRepository;
            _questionService = questionService;
        }

        public DateTime GetAvgSpentTimePerUser(User user)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, int> GetCountOptionsPerQuestion(Question question)
        {
            var dictionary = new Dictionary<int, int>();
            // _userRepository.GetUsers().Select(user => user.Answers.Where(answer => answer.QuestionId == question.Id).ToList().);

            var users = _userRepository.GetUsers();
            foreach (var user in users)
            {
                var id = user.Answers.First(answer => answer.QuestionId == question.Id).Options.First().Id;
                if (dictionary.ContainsKey(id))
                {
                    dictionary[id] = dictionary[id] + 1;
                }
                else
                {
                    dictionary.Add(id, 1);
                }
            }

            for (int i = 1; i <= question.Options.Count(); i++)
            {
                Console.WriteLine(i);
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i, 0);
                }
            }


            // var x = _userRepository.GetUsers().SelectMany(u => u.Answers.Where(a => a.QuestionId == question.Id).SelectMany(a => a.Options ).Select(op => new { op.Id,})).GroupBy(op => op.Id);
            return dictionary;
        }

        public List<int> GetCountOptionsPerQuestionList(Question question)
        {
            return GetCountOptionsPerQuestion(question).OrderBy(kp => kp.Key)
                .Select(kp => kp.Value)
                .ToList();
        }

        public DateTime GetSpentTimePerUser(User user)
        {
            throw new NotImplementedException();
        }

        public int GetUsersCount()
        {
            return _userRepository.GetUsers().Count();
        }

        public void ShowStates()
        {
            Console.WriteLine($"Number of users : {GetUsersCount()}\n\n\n");

            _questionService.GetQuestions().ToList().ForEach(q =>
            {
                Console.WriteLine($"\n\nQuestion : {q.Title}");
                var dic = GetCountOptionsPerQuestion(q);
                dic.ToList().ForEach(s => Console.WriteLine($"\t{q.Options.First(o => o.Id == s.Key)} : {s.Value}"));
            });
        }
    }
}