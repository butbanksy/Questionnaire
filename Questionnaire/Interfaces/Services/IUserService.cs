using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace Questionnaire.Interfaces.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void AddAnswer(User user, Answer answer);
        IEnumerable<User> GetUsers();


    }
}
