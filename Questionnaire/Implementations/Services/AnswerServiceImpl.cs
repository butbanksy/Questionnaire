using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Helpers.GeneralHelpers;
using Questionnaire.Interfaces.Repositories;
using Questionnaire.Interfaces.Services;
using Questionnaire.Models;

namespace Questionnaire.Implementations.Services
{
    class AnswerServiceImpl : IAnswerService
    {

        IAnswerRepository _answerRepository;

        AnswerServiceImpl(IAnswerRepository answerRepository)
        {
            this._answerRepository = answerRepository;
        }
        public IEnumerable<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAllAnswers();
        }

        public Answer GetAnswer(int[] indcies, Question q)
        {
            IEnumerable<Option> options = indcies.Select(i => MainHelpers.getOption(i - 1 , q));

            Answer answer = new Answer()
            {

                QuestionId = q.Id,
                Options = options,
            };

            return answer;
        }
    }
}
