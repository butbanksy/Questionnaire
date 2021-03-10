
using Questionnaire.Models;

namespace Questionnaire.Interfaces.Services
{
    public interface IUserService
    {
        User AddUser(User user);
        void AddAnswer(User user, Answer answer);
    }
}
