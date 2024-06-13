using Newtonsoft.Json;
using Radiologi___Frontend___Maui.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace Radiologi___Frontend___Maui.Services
{
    public class UserService
    {
        static string BaseUrl = "https://localhost:7290";

        static HttpClient client;

        static UserService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<User> Login(User user)
        {
            user.Password = HashPassword(user.Password);

            JsonContent content = JsonContent.Create(user);

            var response = await client.PostAsync("api/User/{user.name}", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var createdUser = JsonConvert.DeserializeObject<User>(responseContent);
                return createdUser;
            }
            else
                return null;

        }

        public async Task<string> CreateUser(User user)
        {
            user.Password = HashPassword(user.Password);

            // Creates a new Json Content based on the object
            JsonContent content = JsonContent.Create(user);

            // Attempts to post and returns the response status
            var response = await client.PostAsync("api/User", content);
            var strResponse = response.StatusCode.ToString();

            return strResponse;
        }

        public async Task<User> GetUserById(string Id)
        {
            var response = await client.GetAsync($"api/User/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var createdUser = JsonConvert.DeserializeObject<User>(responseContent);
                return createdUser;
            }
            else
                return null;
        }

        private string HashPassword(string password)
        {
            // Hashes the password and returns it as a string
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<List<string>> GetClassesByIUserd(string Id)
        {
            var response = await client.GetAsync($"api/User/Classes/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var createdUser = JsonConvert.DeserializeObject<List<string>>(responseContent);
                return createdUser;
            }
            else
                return null;
        }
    }
}
