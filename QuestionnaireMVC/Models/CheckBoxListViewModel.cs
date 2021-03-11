using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Models
{
    public class CheckBoxListViewModel
    {
        public CheckBox[] ListCheckBox { get; set; }

        public CheckBoxListViewModel()
        {
           
        }

        public List<Question> questions { get; set; }
    }

    public class CheckBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}
