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
    public class AnswerServiceImpl : IAnswerService
    {

        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionService _questionService;

        public AnswerServiceImpl(IAnswerRepository answerRepository, IQuestionService questionService)
        {
            _answerRepository = answerRepository;
            _questionService = questionService;
        }
        public IEnumerable<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAllAnswers();
        }

        public Answer GetAnswer(int[] indcies, Question q)
        {
            IEnumerable<Option> options = indcies.ToList().Select(i => MainHelpers.getOption(i - 1, q)).ToList();
            // Option option = MainHelpers.getOption(indcies[0], q);

            Answer answer = new Answer()
            {

                QuestionId = q.Id,
                Options = options,
            };

            return answer;
        }

        public Answer SubmitAnswer(int questionId, int userId, int[] indexes)
        {
            var question = _questionService.GetQuestionById(questionId);
            IEnumerable<Option> options = indexes.ToList().Select(i => MainHelpers.getOption(i - 1, question)).ToList();

            Answer answer = new Answer()
            {
                QuestionId = questionId,
                Options = options,
                UserId = userId
            };
            return answer;
        }
    }
}
