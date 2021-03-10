using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Helpers.StringHelpers
{
    public static class StringHelpers
    {

        public static bool isNullOrEmpty(this string s)
        {

            return s == null || s == "";
        }

        public static bool isValidMail(this string s)
        {

            try
            {
                var addr = new System.Net.Mail.MailAddress(s);
                return addr.Address == s;
            }
            catch
            {
                return false;
            }
        }
    }
}
