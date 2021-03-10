using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace Questionnaire.Interfaces.Services
{
    public interface IStatisticsService
    {
        public int GetUsersCount(); 
        public IDictionary<int,int> GetCountOptionsPerQuestion(Question question);

        public DateTime GetSpentTimePerUser(User user);
        public DateTime GetAvgSpentTimePerUser(User user);

        public void ShowStates();
    }
}
