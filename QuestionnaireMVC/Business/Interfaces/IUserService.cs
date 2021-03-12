using Questionnaire.Models;
using System.Collections.Generic;

namespace QuestionnaireMVC.Business.Interfaces
{
    public interface IUserService
    {
     
        // dont forget to add answer in the process of adding users
        void AddUser(User user);
        void AddAnswer(User user, Answer answer);
        IEnumerable<User> GetUsers();


    }
}
