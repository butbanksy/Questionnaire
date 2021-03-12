using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Option> Options{ get; set; }

        public override string ToString()
        {
            string str = $"Question ID {QuestionId}";
            str += string.Join("\n", Options.ToList().Select(o => o.Title).ToArray());
            return str;
        }
    }
}