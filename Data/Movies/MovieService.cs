using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Movies
{
    public class MovieService : IMovieService
    {
        string url = "https://localhost:7176/movie";
        HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Movie result = JsonSerializer.Deserialize<Movie>(message);
            return result;
        }
    }
}
