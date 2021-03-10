
using Questionnaire.Models;
using System.Collections.Generic;

namespace Questionnaire.Interfaces.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void AddAnswer(User user, Answer answer);
        IEnumerable<User> GetUsers();


    }
}
