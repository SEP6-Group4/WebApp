using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Data.FavoriteMovie
{
    public class FavoriteMovieService : IFavoriteMovieService
    {
#if DEBUG
        string url = "https://localhost:7176/api/FavoriteMovie";
#else
       
        string url = "http://moviewebapi-dev.us-east-1.elasticbeanstalk.com/api/FavoriteMovie";
#endif
        HttpClient client;

        public FavoriteMovieService()
        {
            client = new HttpClient();
        }

        public async Task AddFavoriteMovie(int userID, int movieID)
        {
            HttpContent content = new StringContent(
                "",
                Encoding.UTF8,
                "application/json"
                );
            await client.PostAsync(url + "/addFavorite?userID=" + userID + "&movieID=" + movieID, content);
        }

        public async Task<int> GetFavoriteMovieCount(int movieID)
        {
            string message = await client.GetStringAsync(url + "/getFavoriteMovieCount?movieID=" + movieID);
            int results = JsonSerializer.Deserialize<int>(message);
            return results;
        }

        public async Task<MovieList> GetFavoriteMoviesByID(int userID)
        {
            string message = await client.GetStringAsync(url + "/getFavorites?userID=" + userID);
            MovieList results = JsonSerializer.Deserialize<MovieList>(message);
            return results;
        }

        public async Task<List<Movie>> GetFavoriteMoviesByUser(int userID)
        {
            string message = await client.GetStringAsync(url + "/getFavoritesByUser?userID=" + userID);
            List<Movie> results = JsonSerializer.Deserialize<List<Movie>>(message);
            return results;
        }

        public async Task<List<IdCount>> GetFavoriteMoviesByAgeGroup(int ageGroup)
        {
            string message = await client.GetStringAsync(url + "/getFavoriteMovieIdsByAgeGroup?ageGroup=" + ageGroup);
            List<IdCount> result = JsonSerializer.Deserialize<List<IdCount>>(message);
            return result;
        }

        public async Task<List<IdCount>> GetFavoriteMoviesByAll()
        {
            string message = await client.GetStringAsync(url + "/getFavoriteMovieIdsByAll");
            List<IdCount> result = JsonSerializer.Deserialize<List<IdCount>>(message);
            return result;
        }

        public async Task<bool> GetIsFavoriteMovieByID(int userID, int movieID)
        {
            string message = await client.GetStringAsync(url + "/getFavorite?userID=" + userID + "&movieID=" + movieID);
            bool result = JsonSerializer.Deserialize<bool>(message);
            return result;
        }
        
        public async Task<MovieList> GetFavoriteMoviesByEmail(string email)
        {
            string message = await client.GetStringAsync(url + "/getFavoritesByEmail?email=" + email);

            try
            {
                MovieList result = JsonSerializer.Deserialize<MovieList>(message);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task RemoveFavoriteMovieByID(int userID, int movieID)
        {
            await client.DeleteAsync(url + "/removeFavorite?userID=" + userID + "&movieID=" + movieID);
        }
    }
}
