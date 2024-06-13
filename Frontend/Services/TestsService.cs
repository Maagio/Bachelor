using Newtonsoft.Json;
using Radiologi___Frontend___Maui.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Radiologi___Frontend___Maui.Services
{
    public class TestsService
    {
        static string BaseUrl = "https://localhost:7290";

        static HttpClient client;

        static TestsService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<string> CreateTest(Questionare questionare)
        {
            // Creates a new Json Content based on the object
            JsonContent content = JsonContent.Create(questionare);

            // Attempts to post and returns the response status
            var response = await client.PostAsync("api/Test", content);
            var strResponse = response.StatusCode.ToString();

            return strResponse;
        }

        public async Task<List<Questionare>> GetTestsByClassId(string classId)
        {
            var response = await client.GetAsync($"api/Test/Classes/{classId}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var questionares = JsonConvert.DeserializeObject<List<Questionare>>(responseContent);
                return questionares;
            }
            else
                return null;
        }

        public async Task<Questionare> GetTestByTestId(string testId)
        {
            var response = await client.GetAsync($"api/Test/{testId}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var questionare = JsonConvert.DeserializeObject<Questionare>(responseContent);
                return questionare;
            }
            else
                return null;
        }
        public async Task<string> SaveAnswers(AnsweredTest answeredTest)
        {
            // Creates a new Json Content based on the object
            JsonContent content = JsonContent.Create(answeredTest);

            // Attempts to post and returns the response status
            var response = await client.PostAsync("api/Test/Answered", content);
            var strResponse = response.StatusCode.ToString();

            return strResponse;
        }
    }
}
