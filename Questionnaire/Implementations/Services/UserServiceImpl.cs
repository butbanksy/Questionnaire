using Questionnaire.Interfaces.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Implementations.Services
{
    class UserServiceImpl : IUserService
    {
        IUserRepository userRepository;
        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }
        public void AddAnswer(User user, Answer answer)
        {
            user.Answers.Append(answer);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }


    }
}

