using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.Movies
{
    public class MovieService : IMovieService
    {
#if DEBUG
        string url = "https://localhost:7176/movie";
#else
       
        string url = "http://moviewebapi-prod.us-east-1.elasticbeanstalk.com/movie";
#endif

        HttpClient client;
        private int movieId = 0;

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

        public async Task<MovieList> GetMoviesByRatingDesc(int page)
        {
            string message = await client.GetStringAsync(url + "/ByRatingDesc?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }

        public async Task<MovieList> GetMoviesByRatingAsc(int page)
        {
            string message = await client.GetStringAsync(url + "/ByRatingAsc?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }

        public async Task<MovieList> GetMoviesByTitleAsc(int page)
        {
            string message = await client.GetStringAsync(url + "/ByTitleAsc?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }

        public async Task<MovieList> GetMoviesByTitleDesc(int page)
        {
            string message = await client.GetStringAsync(url + "/ByTitleDesc?page=" + page);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }


        public async Task<Credit> GetCreditsByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + "/" + movieId + "/credits");
            Credit result = JsonSerializer.Deserialize<Credit>(message);
            return result;
        }

        public int GetMovieId()
        {
            return movieId;
        }

        public void SetMovieId(int id)
        {
            movieId = id;
        }
        public async Task<MovieList> GetMoviesBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }
    }
}
