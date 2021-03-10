using System.Collections.Generic;

namespace Questionnaire.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Option> Options{ get; set; }
    }
}