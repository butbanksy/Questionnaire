using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace Questionnaire.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestionById(int id);
    }
}
