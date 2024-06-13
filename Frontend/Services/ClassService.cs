using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Radiologi___Frontend___Maui.Models;

namespace Radiologi___Frontend___Maui.Services
{
    public class ClassService
    {
        static string BaseUrl = "https://localhost:7290";

        static HttpClient client;

        static ClassService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<Class>> GetClassesByIds(List<string> classIds)
        {
            List<Class> classes = new List<Class>();

            foreach (string id in classIds)
            {
                var response = await client.GetAsync($"api/Class/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var foundClass = JsonConvert.DeserializeObject<Class>(responseContent);
                    classes.Add(foundClass);
                }
            }

            return classes;
        }
    }
}
