using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime TimeOfCompletion { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Answers = new Answer[] { };
        }

        public override string ToString()
        {
            return $"\n Name : {Name}, Email: {Email}";
        }
    }
}
