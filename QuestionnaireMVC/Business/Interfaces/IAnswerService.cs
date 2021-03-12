﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Models;

namespace Questionnaire.Interfaces.Services
{
    public interface IAnswerService
    {
        Answer GetAnswer(int[] indecies, Question q);
        IEnumerable<Answer> GetAllAnswers();
        Answer SubmitAnswer(int questionId, int userId, int[] id);
    }
}
