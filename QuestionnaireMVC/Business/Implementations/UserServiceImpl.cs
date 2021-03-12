using QuestionnaireMVC.Business.Interfaces;
using QuestionnaireMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestionnaireMVC.Business.Implementations
{
    public class UserServiceImpl : IUserService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonSerializerOptions;
        private string url ="api/";
        public UserServiceImpl(HttpClient client)
        {
            _httpClient = client;
        }
     
        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _httpClient.GetAsync($"{url}users");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<User>>(responseStream);
        }

        public async Task AddAnswer(User user, Answer answer)
        {
            user.Answers.ToList().Add(answer);
            var answerItemJson = new StringContent(
        JsonSerializer.Serialize(answer, _jsonSerializerOptions),
        Encoding.UTF8,
        "application/json");

            using var httpResponse = await _httpClient.PutAsync($"{url}answerItemJson", answerItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task AddUser(User user)
        {
            var userItemJson = new StringContent(
         JsonSerializer.Serialize(user, _jsonSerializerOptions),
         Encoding.UTF8,
         "application/json");

            using var httpResponse = await _httpClient.PostAsync($"{url}userItemJson", userItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        

        public async Task AddAnswers(User user, IEnumerable<Answer> answer)
        {
            user.Answers = answer;
            var userJson = new StringContent(
        JsonSerializer.Serialize(user, _jsonSerializerOptions),
        Encoding.UTF8,
        "application/json");

            using var httpResponse = await _httpClient.PutAsync("/api/userJson", userJson);

            httpResponse.EnsureSuccessStatusCode();
        }
    }
 }

