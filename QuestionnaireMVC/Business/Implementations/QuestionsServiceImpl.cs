using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace QuestionnaireMVC.Business.Implementations
{
    public class QuestionsServiceImpl : IQuestionService
    {

        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonSerializerOptions;
        private string url = "api/";
        public QuestionsServiceImpl(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<Question> GetQuestionById(int id)
        {
            var response = await _httpClient.GetAsync($"{url}users/{id}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Question>(responseStream);
        }

        public async Task<IEnumerable<Option>> GetQuestionOptions(int id)
        {
            var response = await _httpClient.GetAsync($"{url}questions/options");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Option>>(responseStream);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var response = await _httpClient.GetAsync($"{url}questions");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Question>>(responseStream);
        }

       
    }
}
