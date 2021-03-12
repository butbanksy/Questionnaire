using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionnaireMVC.Models;

namespace QuestionnaireMVC.Helpers.GeneralHelpers
{
    public static class MainHelpers
    {


        public static Option getOption(int index, Question q)
        {
            return q.Options
                .Select((option, i) => new { i, option })
                .Where(item => index == item.i)
                .Select(item => item.option )
                .FirstOrDefault();
        }



    }
}
