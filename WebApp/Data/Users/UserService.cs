using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Users
{
    public class UserService : IUserService
    {
        //string url = "http://webapi-sep6-dev.us-east-1.elasticbeanstalk.com/user";
        string url = "https://localhost:7176/api/user";
        HttpClient client;

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            Console.WriteLine("Validating with API...");
            string message = await client.GetStringAsync($"{url}/validate?email={email}&password={password}");
            Console.WriteLine("Response received");
            try
            {
                Console.WriteLine("Deserializing...");
                User result = JsonSerializer.Deserialize<User>(message);
                Console.WriteLine("Deserialization complete");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

            /*
            Console.WriteLine("Validating...");
            string userAsJson = JsonSerializer.Serialize(new User { Email = email, Password = password });
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + "/validate"),
                Content = new StringContent(userAsJson, Encoding.UTF8, "application/json")
            };
            
            var response = await client.SendAsync(request);
            Console.WriteLine("Got response");

            try
            {
                Console.WriteLine("Deserializing...");
                var responseData = await response.Content.ReadAsStringAsync();
                User result = JsonSerializer.Deserialize<User>(responseData);
                Console.WriteLine("Deserialization success");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            */
        }
    }
}
