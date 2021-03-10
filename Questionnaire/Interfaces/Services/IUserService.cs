<<<<<<< HEAD
﻿
using Questionnaire.Models;
=======
﻿using Questionnaire.Models;
>>>>>>> 8b66394f40ced8b7de6d21cb7ef0d7250ebf4e41
using System.Collections.Generic;

namespace Questionnaire.Interfaces.Services
{
    public interface IUserService
    {
     
        // dont forget to add answer in the process of adding users
        void AddUser(User user);
        void AddAnswer(User user, Answer answer);
        IEnumerable<User> GetUsers();


    }
}
