using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Option> Options { get; set; }

        public override string ToString()
        {
            string options = String.Join("", Options.ToList().Select((option, i) => $"\n\t({i + 1}) {option}"));
            return $"\n{Title} \n{options}";
        }
    }
}
