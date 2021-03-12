using Questionnaire.Models;
using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Helpers.GeneralHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Business.Implementations
{
    public class AnswerServiceImpl : IAnswerService
    {

        private readonly HttpClient _httpClient;
        private IQuestionService _questionService;
        private JsonSerializerOptions _jsonSerializerOptions;
        private string url = "api/";

        public AnswerServiceImpl(HttpClient client, IQuestionService questionService)
        {
            _httpClient = client;
            _questionService = questionService;
        }
        public async Task<IEnumerable<Answer>> GetAllAnswers()
        {
            var response = await _httpClient.GetAsync($"{url}answers");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Answer>>(responseStream);
        }

        public Answer  GetAnswer(int[] indecies, Question q)
        {
            IEnumerable<Option> options = indecies.ToList().Select(i => MainHelpers.getOption(i - 1, q)).ToList();
            // Option option = MainHelpers.getOption(indcies[0], q);

            Answer answer = new Answer()
            {

                QuestionId = q.Id,
                Options = options,
            };

            return answer;
        }

        public async Task SubmitAnswer(int questionId, int userId, int[] indexes)
        {
            var question = _questionService.GetQuestionById(questionId).Result;
            IEnumerable<Option> options = indexes.ToList().Select(i => MainHelpers.getOption(i - 1, question)).ToList();

            Answer answer = new Answer()
            {
                QuestionId = questionId,
                Options = options,
                UserId = userId
            };

            var answerItemJson = new StringContent(
         JsonSerializer.Serialize(answer, _jsonSerializerOptions),
         Encoding.UTF8,
         "application/json");

            using var httpResponse = await _httpClient.PostAsync($"{url}answerItemJson", answerItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
