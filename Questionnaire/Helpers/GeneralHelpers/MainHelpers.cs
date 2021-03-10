using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace Questionnaire.Helpers.GeneralHelpers
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
