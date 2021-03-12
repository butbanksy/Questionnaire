using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IStatisticsService
    {
        public int GetUsersCount(); 
        public IDictionary<int,int> GetCountOptionsPerQuestion(Question question);
        public List<int> GetCountOptionsPerQuestionList(Question question);

        public DateTime GetSpentTimePerUser(User user);
        public DateTime GetAvgSpentTimePerUser(User user);

        public void ShowStates();
    }
}
