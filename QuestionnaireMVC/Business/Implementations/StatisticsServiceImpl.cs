using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Models;

namespace QuestionnaireMVC.Business.Implementations
{
    public class StatisticsServiceImpl : IStatisticsService
    {

        private readonly IUserService _userService;
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonSerializerOptions;


        public StatisticsServiceImpl(HttpClient httpClient, IUserService userService) {
            _httpClient = httpClient;
            _userService = userService;
        }
        public DateTime GetAvgSpentTimePerUser(User user)
        {
            throw new NotImplementedException();
        }
        public DateTime GetSpentTimePerUser(User user)
        {
            throw new NotImplementedException();
        }
        
        
        public IDictionary<int, int> GetCountOptionsPerQuestion(Question question)
        {
            var dictionary = new Dictionary<int, int>();
   

            var users =  _userService.GetUsers().Result;
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


           
            return dictionary;
        }

        public List<int> GetCountOptionsPerQuestionList(Question question)
        {
            return GetCountOptionsPerQuestion(question).OrderBy(kp => kp.Key)
                .Select(kp => kp.Value)
                .ToList();
        }

        

        public int GetUsersCount()
        {
            return _userService.GetUsers().Result.Count();
        }

        public void ShowStates()
        {
            throw new NotImplementedException();
        }
    }
}
