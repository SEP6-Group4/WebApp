﻿using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Users
{
    public class UserService : IUserService
    {
        //string url = "http://webapi-sep6-dev.us-east-1.elasticbeanstalk.com/user";
        string url = "https://localhost:7176/api/user";
        HttpClient client;

        private int userId;

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            string message = await client.GetStringAsync($"{url}/validate?email={email}&password={password}");
            Console.WriteLine("Response received");
            try
            {
                User result = JsonSerializer.Deserialize<User>(message);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public void SetUserId(int id)
        {
            userId = id;
        }

        public int GetUserId()
        {
            return userId;
        }

        public async Task CreateAccount(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PostAsync($"{url}/createAccount", content);
        }
    }
}
