using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionnaireMVC.Models;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IAnswerService
    {
        Answer GetAnswer(int[] indecies, Question q);
        Task<IEnumerable<Answer>> GetAllAnswers();
        Task<Answer> SubmitAnswer(int questionId, int userId, int[] id);
    }
}
