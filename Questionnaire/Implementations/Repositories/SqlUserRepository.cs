using Microsoft.EntityFrameworkCore;
using Questionnaire.Data;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Models;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Users.Include("Answers").FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include("Answers");
        }
    }
}