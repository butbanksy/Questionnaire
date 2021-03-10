using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers();


    }
}
