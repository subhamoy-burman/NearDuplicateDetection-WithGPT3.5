using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the first question:");
        string question1 = Console.ReadLine();

        Console.WriteLine("Enter the second question:");
        string question2 = Console.ReadLine();

        string result = await DetermineSimilarity(question1, question2);
        Console.WriteLine($"The questions are: {result}");
    }

    static async Task<string> DetermineSimilarity(string q1, string q2)
        {
            string apiKey = "YOUR_OPEN_AI_KEY";
            string apiUrl = "https://api.openai.com/v1/chat/completions";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = $"Label this pair of questions as 'similar' or 'not similar', and return the label: '{q1}' and '{q2}'. Provide rationale before answering." }
            };

            var requestBody = new
            {
                model = "gpt-3.5-turbo-instruct",
                messages = messages,
                max_tokens = 100,
                temperature = 0.7
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(responseString);
            string label = result.choices[0].message.content.Trim();

            return label;
        }
    }
