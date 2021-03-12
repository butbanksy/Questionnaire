using Questionnaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IUserService
    {

        // dont forget to add answer in the process of adding users
        Task AddUser(User user);
        Task AddAnswer(User user, Answer answer);

        Task AddAnswers(User user, IEnumerable<Answer> answer);
        Task<IEnumerable<User>> GetUsers();


    }
}
