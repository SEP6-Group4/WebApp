using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Actors
{
    public class ActorService : IActorService
    {
#if DEBUG
        string url = "https://localhost:7176/actor";
#else
       
        string url = "http://moviewebapi-dev.us-east-1.elasticbeanstalk.com/actor";
#endif

        HttpClient client;
        private int actorId = 0;

        public ActorService()
        {
            client = new HttpClient();
        }

        public async Task<Actor> GetActorByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Actor result = JsonSerializer.Deserialize<Actor>(message);
            return result;
        }

        public async Task<MovieCredit> GetMovieCreditsByActorId(int actorId)
        {
            string message = await client.GetStringAsync(url + "/" + actorId + "/movie_credits");
            MovieCredit result = JsonSerializer.Deserialize<MovieCredit>(message);
            return result;
        }

        public int GetActorId()
        {
            return actorId;
        }

        public void SetActorId(int id)
        {
            actorId = id;
        }

        public async Task<ActorList> GetPopularActors(int page)
        {
            string message = await client.GetStringAsync(url + "/" + "popularActors?page=" + page);
            ActorList result = JsonSerializer.Deserialize<ActorList>(message);
            return result;
        }

        public async Task<ActorList> GetActorsBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            ActorList results = JsonSerializer.Deserialize<ActorList>(message);
            return results;
        }
    }
}
