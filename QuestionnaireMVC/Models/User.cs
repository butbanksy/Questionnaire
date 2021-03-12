using System;
using System.Collections.Generic;

namespace QuestionnaireMVC.Models
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
            Id = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            Name = name;
            Email = email;
            Answers = new Answer[] { };
        }
        public User()
        {

        }

        public override string ToString()
        {
            return $"\n Name : {Name}, Email: {Email}";
        }

        public void GenerateUserId()
        {
            Id = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}
