using WebApp.Models;

namespace WebApp.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);
        Task<MovieList> GetMoviesByRatingDesc(int page);
        Task<MovieList> GetMoviesByRatingAsc(int page);
        Task<MovieList> GetMoviesByTitleAsc(int page);
        Task<MovieList> GetMoviesByTitleDesc(int page);
        Task<Credit> GetCreditsByMovieId(int movieId);
        void SetMovieId(int id);
        int GetMovieId();
        Task<MovieList> GetMoviesBySearch(int page, string query);
    }
}
