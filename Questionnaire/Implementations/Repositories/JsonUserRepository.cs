using Questionnaire.Helpers;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Implementations.Repositories
{
    public class JsonUserRepository : IUserRepository
    {
        private readonly IEnumerable<User> _users;

        public JsonUserRepository()
        {
            _users = DataHelper<User>.LoadJson();
        }

        public void AddUser(User user)
        {
            var list = _users.ToList();
            list.Add(user);
            DataHelper<User>.SaveJson(list);
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
