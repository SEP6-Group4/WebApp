using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Movies
{
    public class MovieService : IMovieService
    {

#if DEBUG
        string url = "https://localhost:7176/movie";
#else
       
        string url = "http://webapi-sep6-dev.us-east-1.elasticbeanstalk.com/movie";
#endif
       
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

        public async Task<MovieList> GetMovies(int page)
        {
            string message = await client.GetStringAsync(url + "?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }

        public async Task<MovieList> GetMoviesBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }
    }
}
