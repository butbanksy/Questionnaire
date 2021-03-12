using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace QuestionnaireMVC.Interfaces.Services
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestionById(int id);

        IEnumerable<Option> GetQuestionOptions(int id);
    }
}
