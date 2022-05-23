using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.FavouriteActor
{
    public class FavouriteActorService : IFavouriteActorService
    {
#if DEBUG
        string url = "https://localhost:7176/FavouriteActor";
#else
       
        string url = "http://moviewebapi-dev.us-east-1.elasticbeanstalk.com/FavouriteActor";
#endif

        HttpClient client;

        public FavouriteActorService()
        {
            client = new HttpClient();
        }

        public async Task AddActorToFavourite(int userId, int actorId)
        {
            HttpContent content = new StringContent("", Encoding.UTF8, "application/json");

            await client.PostAsync(url + "/AddActorToFavourite/" + userId + "/" + actorId, content);
        }

        public async Task RemoveActorFromFavourite(int userId, int actorId)
        {
            await client.DeleteAsync(url + "/RemoveActorFromFavourite/" + userId + "/" + actorId);
        }

        public async Task<List<int>> GetFavouriteActorIds(int userId)
        {
            string message = await client.GetStringAsync(url + "/GetFavouriteActorIds/" + userId);
            List<int> result = JsonSerializer.Deserialize<List<int>>(message);
            return result;
        }

        public async Task<List<Actor>> GetFavouriteActorsByEmail(string email)
        {
            string message = await client.GetStringAsync(url + "/GetFavouriteActorIdsByEmail/" + email);
            try
            {
                List<Actor> result = JsonSerializer.Deserialize<List<Actor>>(message);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
