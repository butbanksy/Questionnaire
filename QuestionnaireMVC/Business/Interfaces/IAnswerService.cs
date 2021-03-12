using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IAnswerService
    {
        Answer GetAnswer(int[] indecies, Question q);
        Task<IEnumerable<Answer>> GetAllAnswers();
        Task SubmitAnswer(int questionId, int userId, int[] id);
    }
}
