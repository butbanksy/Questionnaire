using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionnaireMVC.Models;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IQuestionService
    {
        
        Task<Question> GetQuestionById(int id);

        Task<IEnumerable<Option>> GetQuestionOptions(int id);
        Task<IEnumerable<Question>> GetQuestions();
    }
}
