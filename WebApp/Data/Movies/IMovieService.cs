using WebApp.Models;

namespace WebApp.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);
        Task<MovieList> GetMovies(int page);
        Task<Credit> GetCreditsByMovieId(int movieId);
        void SetMovieId(int id);
        int GetMovieId();
    }
}
