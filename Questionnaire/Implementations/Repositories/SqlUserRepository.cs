using Questionnaire.Data;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System.Collections.Generic;

namespace Questionnaire.Implementations.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly QuestionnaireContext _context;

        public SqlUserRepository(QuestionnaireContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.AddAsync(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}