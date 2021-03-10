using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Questionnaire.Helpers
{
    public static class DataHelper<T>
    {
        public static IEnumerable<T> LoadJson()
        {

            string path = "";

            /*
            switch (typeof(T))
            {
                case typeof(Question):
                    {
                        path = $"../../../Resources/questions.json";
                        break;
                    }
                case User:
                    {
                        path = $"../../../Resources/users.json";
                        break;
                    }
                default:
                    {
                        path = $"../../../Resources/questions.json";
                        break;
                    }
            }
            */

            if(typeof(Question) == typeof(T))
            {
                path = $"../../../Resources/questions.json";
                Console.WriteLine(typeof(T));
            }else if(typeof(User) == typeof(T))
            {
                path = $"../../../Resources/users.json";
            }


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var fileJson = File.ReadAllText(path);

            return JsonSerializer.Deserialize<IEnumerable<T>>(fileJson, options);

        }
    }
}
